import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule, Router } from '@angular/router';
import { CategoryService, Category } from './category.service';

@Component({
  selector: 'app-category-detail',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './category-detail.component.html'
})
export class CategoryDetailComponent implements OnInit {
  category: Category | null = null;
  loading = true;
  error = '';

  constructor(private route: ActivatedRoute, private service: CategoryService, private router: Router) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.service.getCategoryById(id).subscribe({
      next: cat => {
        this.category = cat;
        this.loading = false;
      },
      error: () => {
        this.error = 'Error cargando categoría';
        this.loading = false;
      }
    });
  }
}
