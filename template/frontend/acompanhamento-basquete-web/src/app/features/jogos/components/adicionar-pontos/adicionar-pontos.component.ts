import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { JogoService } from '../../services/jogo.service';
import { ToasterService } from '../../../../core/services/toaster.service';

@Component({
  selector: 'app-adicionar-pontos',
  templateUrl: './adicionar-pontos.component.html',
  styleUrls: ['./adicionar-pontos.component.scss'],
  imports: [CommonModule, ReactiveFormsModule],
  providers: [JogoService]
})
export class AdicionarPontosComponent implements OnInit {

  private _toasterService = inject(ToasterService);
  private _jogoService = inject(JogoService);
  dataAtualISO: string = '';

  jogoForm = new FormGroup({
    data: new FormControl(new Date().toISOString().split('T')[0], Validators.required),
    pontos: new FormControl(null, Validators.required),
  });

  ngOnInit(): void {
    const dataAtual = new Date();
    this.dataAtualISO = dataAtual.toISOString().split('T')[0];
  }

  salvar(): void {
    if (!this.jogoForm.valid) {
      this._toasterService.error('Dados inválido!');
      return;
    }

    const jogo = {
      data: new Date(this.jogoForm.value.data!).toISOString(),
      pontos: this.jogoForm.value.pontos!,
    };

    this._jogoService.salvar(jogo).subscribe({
      next: () => this._toasterService.success('Jogo salvo com sucesso!'),
      error: (err) => {
        if (err.error?.erros && Array.isArray(err.error.erros)) {
          const mensagens = err.error.erros.map((e: any) => e.detalhe).join('\n');
          this._toasterService.error(`Falha ao salvar o jogo:\n${mensagens}`);
        } else {
          this._toasterService.error('Ocorreu um erro inesperado ao salvar o jogo.');
        }
      }
    });
  }

}
