import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { SearchComponent } from './search/search.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FilterPipe } from './filter.pipe';
import { TimeAgoPipe } from './time-ago.pipe';

@NgModule({
  declarations: [LoaderComponent, SearchComponent, FilterPipe, TimeAgoPipe],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MDBBootstrapModule.forRoot()
  ],
  exports: [LoaderComponent, SearchComponent, TimeAgoPipe],
})
export class SharedModule { }
