import { Component } from '@angular/core';
import { BookService } from '../../services/book.service';
import { CategoryService } from '../../services/category.service';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Book } from '../../model/book';
import { Category } from '../../model/category';
import Swal from 'sweetalert2';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-book',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './update-book.component.html',
  styleUrl: './update-book.component.css'
})
export class UpdateBookComponent {

  searchId: number = 0;
  searchedBook?: Book; 
  categories?: Category[];

  constructor(private bookService: BookService, private categoryService: CategoryService,private route:ActivatedRoute,private router:Router) {}

  ngOnInit() {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.searchId = Number(idParam);
      this.getBookById();
    }
    this.getAllCategories();
  }

  getAllCategories(): void {
    this.categoryService.getAllCategories().subscribe(
      (categories: Category[]) => {
        this.categories = categories;
      },
      (error) => {
        console.error('Error fetching categories:', error);
      }
    );
  }

  getBookById(): void {
    this.bookService.getBookById(this.searchId).subscribe(
      (book: Book ) => {
        if (book && book.bookId) {
          this.searchedBook = book;
          Swal.fire('Success', 'Book Found!', 'success');
        } else {
          this.searchedBook = undefined;
          Swal.fire('Error', 'Book not found!', 'error');
        }
      },
      (error) => {
        this.searchedBook = undefined;
        Swal.fire('Error', 'Book not found!', 'error');
        console.error('Book not found:', error);
      }
    );
  }

  updateBook(updateBookForm: NgForm): void {
    if (!this.searchedBook) {
      Swal.fire('Error', 'No book selected for update!', 'error');
      return;
    }

    this.bookService.updateBook(this.searchedBook).subscribe(
      (res) => {
        Swal.fire('Success', 'Book Updated Successfully!', 'success');
        updateBookForm.reset();
        this.searchedBook = undefined;
        this.router.navigateByUrl('/book')

      },
      (error) => {
        Swal.fire('Error', 'Failed to update book!', 'error');
        console.error('Update failed:', error);
      }
    );
  }
}
