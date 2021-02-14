import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { TimeDiffPipe } from './time-diff.pipe';



@NgModule({
  declarations: [LoaderComponent, TimeDiffPipe],
  imports: [
    CommonModule
  ],
  exports: [LoaderComponent, TimeDiffPipe],
})
export class SharedModule { }
