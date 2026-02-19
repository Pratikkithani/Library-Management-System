import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-success-component',
  standalone: true,
  imports: [],
  templateUrl: './success-component.component.html',
  styleUrl: './success-component.component.css'
})
export class SuccessComponentComponent {
@Input() title: string = 'Success';
  @Input() message: string = 'Operation completed successfully';
  @Input() isVisible: boolean = false;

  @Output() closed = new EventEmitter<void>();

  close() {
    this.isVisible = false;
    this.closed.emit();
  }
}
