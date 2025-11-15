import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule, Router } from '@angular/router';
import { CategoryService } from './category.service';

@Component({
  selector: 'app-category-create',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './category-create.component.html'
})
export class CategoryCreateComponent {
  name = '';
  saving = false;
  error = '';

  constructor(private service: CategoryService, private router: Router) {}

  save(): void {
    if (!this.name.trim()) {
      this.error = 'Nombre requerido';
      return;
    }
    this.error = '';
    this.saving = true;
    this.service.createCategory({ name: this.name.trim() }).subscribe({
      next: () => this.router.navigate(['/categorias']),
      error: () => {
        this.error = 'Error guardando categoría';
        this.saving = false;
      }
    });
  }
}
