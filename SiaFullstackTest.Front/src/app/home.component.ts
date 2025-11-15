import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterModule],
  template: `
    <div class="container mt-5">
      <div class="row justify-content-center">
        <div class="col-md-8 text-center">
          <h1 class="display-4 mb-4">Bienvenido a SIA Fullstack Test</h1>
          <p class="lead text-muted">Selecciona una opción del menú superior para comenzar.</p>
          <hr class="my-4">
          <div class="mb-3"><a routerLink="/productos" class="btn btn-primary btn-lg">Ver Productos</a></div>
          <div><a routerLink="/categorias" class="btn btn-primary btn-lg">Ver Categorías</a></div>  
        </div>
      </div>
    </div>
  `,
  styles: []
})
export class HomeComponent { }
