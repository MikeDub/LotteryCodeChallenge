import { FaqComponent } from './faq.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [FaqComponent],
  imports: [
    CommonModule
  ],
  exports: [FaqComponent]
})
export class FaqModule { }
