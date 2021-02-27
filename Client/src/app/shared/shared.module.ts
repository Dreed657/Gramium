import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { TimeDiffPipe } from './time-diff.pipe';
import { SearchComponent } from './search/search.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FilterPipe } from './filter.pipe';



@NgModule({
  declarations: [LoaderComponent, TimeDiffPipe, SearchComponent, FilterPipe],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MDBBootstrapModule.forRoot()
  ],
  exports: [LoaderComponent, TimeDiffPipe, SearchComponent],
})
export class SharedModule { }
