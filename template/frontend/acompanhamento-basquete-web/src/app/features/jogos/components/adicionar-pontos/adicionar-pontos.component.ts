import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { JogoService } from '../../services/jogo.service';

@Component({
  selector: 'app-adicionar-pontos',
  templateUrl: './adicionar-pontos.component.html',
  styleUrls: ['./adicionar-pontos.component.scss'],
  imports: [CommonModule, ReactiveFormsModule],
})
export class AdicionarPontosComponent implements OnInit {

  private _jogoService = inject(JogoService);
  dataAtualISO: string = '';

  ngOnInit() {
    const dataAtual = new Date();
    this.dataAtualISO = dataAtual.toISOString().split('T')[0];
  }

  jogoForm = new FormGroup({
    data: new FormControl(new Date().toISOString().split('T')[0], Validators.required),
    pontos: new FormControl(null, Validators.required),
  });

  salvar(): void{
    if (!this.jogoForm.valid) {
      alert('Dados inválido!');
      return;
    }

    const jogo = {
      data: new Date(this.jogoForm.value.data!).toISOString(),
      pontos: this.jogoForm.value.pontos!,
    };

    this._jogoService.salvar(jogo).subscribe({
      next: () => alert('Jogo salvo!'),
      error: err => console.error(err)
    });
  }

}
