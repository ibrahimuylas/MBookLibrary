import { Component, OnInit } from '@angular/core';


import { IBook } from '../../models/book';
import { IBookFilter } from '../../models/book-filter';
import { BookService } from '../../services/book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  pageTitle = 'Book List';
  imageWidth = 50;
  imageMargin = 2;
  errorMessage = '';
  _listFilter: IBookFilter = { isbn : '', title : '', author : '', genre : '' };

  get listFilter(): IBookFilter {
    return this._listFilter;
  }
  set listFilter(value: IBookFilter) {
    this._listFilter = value;
  }

  books: IBook[] = [];

  constructor(private bookService: BookService) {

  }

  performFilter(filterBy: IBookFilter) {
    this.bookService.getBooks(filterBy).subscribe(
      books => {
        this.books = books;
      },
      error => this.errorMessage = <any>error
    );
  }

  ngOnInit(): void {
    let filterBy: IBookFilter = { isbn: '', title: '', author: '', genre: '' };
    this.performFilter(filterBy);
  }

}
