import { Component } from '@angular/core';
import { Category } from '../../model/category';
import { CategoryService } from '../../services/category.service';
import { FormsModule, NgForm } from '@angular/forms';
import Swal from 'sweetalert2';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent {

    categories?:Category[];
    newCategory: Category = new Category();
    constructor(private categoryService:CategoryService,private router:Router) {}
  
    ngOnInit(){
      this.getAllCategories();
    }
    
    getAllCategories(): void {
      this.categoryService.getAllCategories().subscribe((categories:Category[])=>{
        this.categories=categories;
      }); 
    }
  
    addCategory(addForm:NgForm):void{
        this.categoryService.addCategory(this.newCategory).subscribe(res=>{
          this.categories?.push(res);
          Swal.fire('Success', 'Book Added!', 'success')
          addForm.reset();
          this.router.navigateByUrl('/category')
        })
      }
}
