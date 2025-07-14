import { Component } from '@angular/core';
import { Category } from '../../model/category';
import { CategoryService } from '../../services/category.service';
import Swal from 'sweetalert2';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-update-category',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './update-category.component.html',
  styleUrl: './update-category.component.css'
})
export class UpdateCategoryComponent {

    searchId: number = 0;
    searchedCategory?: Category; 
    categories?: Category[];
  
    constructor(private categoryService: CategoryService,private route:ActivatedRoute,private router:Router) {}
  
    ngOnInit() {
      const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.searchId = Number(idParam);
      this.getCategoryById();
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
  
    getCategoryById(): void {
      this.categoryService.getCategoryById(this.searchId).subscribe(
        (category: Category ) => {
          if (category && category.categoryId) {
            this.searchedCategory = category;
            Swal.fire('Success', 'Category Found!', 'success');
          } else {
            this.searchedCategory = undefined;
            Swal.fire('Error', 'Category not found!', 'error');
          }
        },
        (error) => {
          this.searchedCategory = undefined;
          Swal.fire('Error', 'Category not found!', 'error');
          console.error('Category not found:', error);
        }
      );
    }
  
    updateCategory(updateBookForm: NgForm): void {
      if (!this.searchedCategory) {
        Swal.fire('Error', 'No Category selected for update!', 'error');
        return;
      }
  
      this.categoryService.updateCategory(this.searchedCategory).subscribe(
        (res) => {
          Swal.fire('Success', 'Category Updated Successfully!', 'success');
          updateBookForm.reset();
          this.searchedCategory = undefined;
          this.router.navigateByUrl('/category')

        },
        (error) => {
          Swal.fire('Error', 'Failed to Category book!', 'error');
          console.error('Update failed:', error);
        }
      );
    }
}
