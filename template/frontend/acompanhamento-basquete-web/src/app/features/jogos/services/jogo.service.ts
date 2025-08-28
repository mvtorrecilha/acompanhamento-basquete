import { inject, Injectable } from '@angular/core';
import { ApplicationService } from '../../../core/services/application.service';
import { map, Observable } from 'rxjs';
import { ResultadosPonto } from '../interfaces/resultados-pontos';
import { Jogo } from '../interfaces/jogo';
import { ApiResponse } from '../../../core/interfaces/api-response';

@Injectable({
  providedIn: 'root'
})
export class JogoService {

  private appService = inject(ApplicationService);
  private endpoint = 'jogos';

  obterResultados(): Observable<ResultadosPonto> {
    return this.appService.get<ApiResponse<ResultadosPonto>>(this.endpoint+'/resultados')
      .pipe(
        map(res => res.data)
      );
  }

  salvar(jogo: Jogo): Observable<Jogo> {
    return this.appService.post<Jogo>(this.endpoint, jogo);
  }

}
