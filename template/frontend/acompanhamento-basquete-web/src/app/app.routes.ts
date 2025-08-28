import { Routes } from '@angular/router';
import { AdicionarPontosComponent } from './features/jogos/components/adicionar-pontos/adicionar-pontos.component';
import { ResultadoPontosComponent } from './features/jogos/components/resultado-pontos/resultado-pontos.component';

export const routes: Routes = [
  { path: '', redirectTo: 'adicionar', pathMatch: 'full' },
  { path: 'adicionar', component: AdicionarPontosComponent },
  { path: 'resultados', component: ResultadoPontosComponent }
];
