import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookListComponent } from './components/book-list/book-list.component';
import { BookDetailComponent } from './components/book-detail/book-detail.component';

const routes: Routes = [
  {
    path: '',
    component: BookListComponent
  },
  {
    path: 'books',
    component: BookListComponent
  },
  {
    path: 'books/:id',
    component: BookDetailComponent
  },
 ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
