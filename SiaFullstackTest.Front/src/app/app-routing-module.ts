import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './products/product-list.component';
import { HomeComponent } from './home.component';
import { ProductCreateComponent } from './products/product-create.component';
import { ProductEditComponent } from './products/product-edit.component';
import { ProductDetailComponent } from './products/product-detail.component';
import { CategoryListComponent } from './categories/category-list.component';
import { CategoryCreateComponent } from './categories/category-create.component';
import { CategoryEditComponent } from './categories/category-edit.component';
import { CategoryDetailComponent } from './categories/category-detail.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'productos', component: ProductListComponent },
  { path: 'productos/nuevo', component: ProductCreateComponent },
  { path: 'productos/ver/:id', component: ProductDetailComponent },
  { path: 'productos/editar/:id', component: ProductEditComponent },
  { path: 'categorias', component: CategoryListComponent },
  { path: 'categorias/nuevo', component: CategoryCreateComponent },
  { path: 'categorias/ver/:id', component: CategoryDetailComponent },
  { path: 'categorias/editar/:id', component: CategoryEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
