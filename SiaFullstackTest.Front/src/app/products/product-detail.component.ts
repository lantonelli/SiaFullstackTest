import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { ProductService, Product } from './product.service';

@Component({
  selector: 'app-product-detail',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './product-detail.component.html'
})
export class ProductDetailComponent implements OnInit {
  product: Product | null = null;
  loading = true;
  error = '';

  constructor(
    private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadProduct(+id);
    } else {
      this.error = 'ID de producto no válido';
      this.loading = false;
    }
  }

  loadProduct(id: number) {
    this.productService.getProductById(id).subscribe({
      next: (data) => {
        this.product = data;
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Error al cargar el producto';
        console.error(err);
        this.loading = false;
      }
    });
  }

  goBack() {
    this.router.navigate(['/productos']);
  }

  editProduct() {
    if (this.product) {
      this.router.navigate(['/productos/editar', this.product.productId]);
    }
  }
}
