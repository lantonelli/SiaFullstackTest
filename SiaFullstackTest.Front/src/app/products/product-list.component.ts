import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProductService, Product } from './product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  standalone: true,
  imports: [CommonModule, RouterModule]
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  loading = true;
  error = '';

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.productService.getProducts().subscribe({
      next: (data) => {
        this.products = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Error al cargar productos';
        console.error(err);
        this.loading = false;
      }
    });
  }

  deleteProduct(product: Product) {
    if (confirm(`¿Está seguro que desea eliminar el producto "${product.name}"?`)) {
      this.productService.deleteProduct(product.productId).subscribe({
        next: () => {
          this.products = this.products.filter(p => p.productId !== product.productId);
        },
        error: (err) => {
          this.error = 'Error al eliminar el producto';
          console.error(err);
        }
      });
    }
  }
}
