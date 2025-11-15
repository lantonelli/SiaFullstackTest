import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductService, Product } from './product.service';
import { CategoryService, Category } from '../categories/category.service';

@Component({
  selector: 'app-product-edit',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-edit.component.html'
})
export class ProductEditComponent implements OnInit {
  product: Product = {
    productId: 0,
    name: '',
    description: '',
    image: '',
    categoryIds: []
  };
  categories: Category[] = [];
  selectedCategoryIds: number[] = [];
  
  loading = false;
  loadingProduct = true;
  error = '';
  success = false;

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loadCategories();
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadProduct(+id);
    } else {
      this.error = 'ID de producto no válido';
      this.loadingProduct = false;
    }
  }

  loadCategories() {
    this.categoryService.getCategories().subscribe({
      next: data => this.categories = data,
      error: () => console.error('Error cargando categorías')
    });
  }

  loadProduct(id: number) {
    this.productService.getProductById(id).subscribe({
      next: (data) => {
        this.product = data;
        this.selectedCategoryIds = data.categoryIds ? [...data.categoryIds] : [];
        this.loadingProduct = false;
      },
      error: (err) => {
        this.error = 'Error al cargar el producto';
        console.error(err);
        this.loadingProduct = false;
      }
    });
  }

  onSubmit() {
    if (!this.product.name || !this.product.description) {
      this.error = 'Por favor complete los campos requeridos';
      return;
    }

    this.loading = true;
    this.error = '';
    
    this.product.categoryIds = this.selectedCategoryIds;
    this.productService.updateProduct(this.product).subscribe({
      next: (response) => {
        this.success = true;
        this.loading = false;
        setTimeout(() => {
          this.router.navigate(['/productos']);
        }, 1500);
      },
      error: (err) => {
        this.error = 'Error al actualizar el producto';
        console.error(err);
        this.loading = false;
      }
    });
  }

  onCancel() {
    this.router.navigate(['/productos']);
  }
}
