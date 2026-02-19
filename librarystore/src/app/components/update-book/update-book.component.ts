import { Component } from '@angular/core';
import { BookService } from '../../services/book.service';
import { CategoryService } from '../../services/category.service';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Book } from '../../model/book';
import { Category } from '../../model/category';
import Swal from 'sweetalert2';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomSwal } from '../../services/swal.configuration';

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
          CustomSwal.fire({
                title: 'Book Found!',
                icon: 'success'
              })
        } else {
          this.searchedBook = undefined;
          CustomSwal.fire({
                title: 'Book not found!',
                icon: 'error'
              })
        }
      },
      (error) => {
        this.searchedBook = undefined;
        CustomSwal.fire({
                title: 'Book not found!',
                icon: 'error'
              })
        console.error('Book not found:', error);
      }
    );
  }

  updateBook(updateBookForm: NgForm): void {
    if (!this.searchedBook) {
      CustomSwal.fire({
                title: 'No book selected for update!',
                icon: 'error'
              })
      return;
    }

    this.bookService.updateBook(this.searchedBook).subscribe(
      (res) => {
        CustomSwal.fire({
                title: 'Book Updated Successfully!',
                icon: 'success'
              })
        updateBookForm.reset();
        this.searchedBook = undefined;
        this.router.navigateByUrl('/book')

      },
      (error) => {
        CustomSwal.fire({
                title: 'Failed to update book!',
                icon: 'error'
              })
        console.error('Update failed:', error);
      }
    );
  }
}
