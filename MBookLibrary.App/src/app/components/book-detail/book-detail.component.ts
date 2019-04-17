import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { IBook } from '../../models/book';
import { BookService } from '../../services/book.service';
import { debug } from 'util';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {
  pageTitle = 'Book Detail';
  errorMessage = '';
  book: IBook | undefined;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private bookService: BookService) {
  }

  ngOnInit() {
    debugger;
    const param = this.route.snapshot.paramMap.get('id');
    if (param) {
      const id = +param;
      this.getBook(id);
    }
  }

  getBook(id: number) {
    this.bookService.getBook(id).subscribe(
      book => this.book = book,
      error => this.errorMessage = <any>error);
  }

  onBack(): void {
    this.router.navigate(['/books']);
  }

}
