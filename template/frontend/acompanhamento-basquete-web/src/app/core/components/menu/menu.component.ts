import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  ngOnInit(): void {
  }

  aberto = false;

  toggleDropdown(): void{
    this.aberto = !this.aberto;
  }

  fecharDropdown(): void {
    this.aberto = false;
  }

}
