import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductService } from './product.service';
import { CategoryService, Category } from '../categories/category.service';

@Component({
  selector: 'app-product-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-create.component.html'
})
export class ProductCreateComponent {
  product = {
    name: '',
    description: '',
    image: '',
    categoryIds: [] as number[]
  };
  categories: Category[] = [];
  selectedCategoryIds: number[] = [];
  
  loading = false;
  error = '';
  success = false;

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadCategories();
  }

  loadCategories() {
    this.categoryService.getCategories().subscribe({
      next: data => this.categories = data,
      error: () => console.error('Error cargando categorías')
    });
  }

  onSubmit() {
    if (!this.product.name || !this.product.description) {
      this.error = 'Por favor complete los campos requeridos';
      return;
    }

    this.loading = true;
    this.error = '';
    
    // adjuntar categorías seleccionadas
    this.product.categoryIds = this.selectedCategoryIds;
    this.productService.createProduct(this.product).subscribe({
      next: (response) => {
        this.success = true;
        this.loading = false;
        setTimeout(() => {
          this.router.navigate(['/productos']);
        }, 1500);
      },
      error: (err) => {
        this.error = 'Error al crear el producto';
        console.error(err);
        this.loading = false;
      }
    });
  }

  onCancel() {
    this.router.navigate(['/productos']);
  }
}
