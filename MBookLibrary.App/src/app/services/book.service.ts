import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { IBook } from '../models/book';
import { IBookFilter } from '../models/book-filter';

@Injectable({
  providedIn: 'root'
})

export class BookService {

  private bookApiBaseUrl = 'https://localhost:44318/api/books/';

  constructor(private http: HttpClient) { }

  getBooks(filterBy: IBookFilter): Observable<IBook[]> {
    return this.http.post<IBook[]>(this.bookApiBaseUrl + 'find',filterBy).pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getBook(id: number): Observable<IBook | undefined> {
    return this.http.get<IBook>(this.bookApiBaseUrl + id).pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
