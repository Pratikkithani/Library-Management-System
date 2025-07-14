import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { BookService } from '../../services/book.service';
import { CategoryService } from '../../services/category.service';
import { Book } from '../../model/book';
import { Category } from '../../model/category';
import Swal from 'sweetalert2';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-book',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent {

  books?:Book[];
  categories?:Category[];
  newBook: Book = new Book();
  constructor(private bookService:BookService,private categoryService:CategoryService,private router:Router) {}

  ngOnInit(){
    this.getAllCategories();
  }
  
  getAllCategories(): void {
    this.categoryService.getAllCategories().subscribe((categories:Category[])=>{
      this.categories=categories;
      console.log(this.categories);
    }); 
  }

  addBook(addForm:NgForm):void{
      this.bookService.addBook(this.newBook).subscribe(res=>{
        console.log(res);
        this.books?.push(res);
        Swal.fire('Success', 'Book Added!', 'success')
        addForm.reset();
        this.router.navigateByUrl('/book')

      })
    }
}
