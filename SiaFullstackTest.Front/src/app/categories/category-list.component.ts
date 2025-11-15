import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Router } from '@angular/router';
import { CategoryService, Category } from './category.service';

@Component({
  selector: 'app-category-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './category-list.component.html'
})
export class CategoryListComponent implements OnInit {
  categories: Category[] = [];
  loading = false;
  error = '';

  constructor(private service: CategoryService, private router: Router) {}

  ngOnInit(): void {
    this.fetch();
  }

  fetch(): void {
    this.loading = true;
    this.service.getCategories().subscribe({
      next: data => {
        this.categories = data;
        this.loading = false;
      },
      error: () => {
        this.error = 'Error cargando categorías';
        this.loading = false;
      }
    });
  }

  delete(id: number): void {
    if (!confirm('¿Eliminar categoría?')) return;
    this.service.deleteCategory(id).subscribe({
      next: () => this.fetch(),
      error: () => alert('Error eliminando categoría')
    });
  }
}
