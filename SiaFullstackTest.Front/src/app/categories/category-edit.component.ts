import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { CategoryService, Category } from './category.service';

@Component({
  selector: 'app-category-edit',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './category-edit.component.html'
})
export class CategoryEditComponent implements OnInit {
  category: Category | null = null;
  name = '';
  loading = true;
  saving = false;
  error = '';

  constructor(private route: ActivatedRoute, private service: CategoryService, private router: Router) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.service.getCategoryById(id).subscribe({
      next: cat => {
        this.category = cat;
        this.name = cat.name;
        this.loading = false;
      },
      error: () => {
        this.error = 'Error cargando categoría';
        this.loading = false;
      }
    });
  }

  save(): void {
    if (!this.category) return;
    if (!this.name.trim()) {
      this.error = 'Nombre requerido';
      return;
    }
    this.error = '';
    this.saving = true;
    this.service.updateCategory({ categoryId: this.category.categoryId, name: this.name.trim() }).subscribe({
      next: () => this.router.navigate(['/categorias']),
      error: () => {
        this.error = 'Error guardando cambios';
        this.saving = false;
      }
    });
  }
}
