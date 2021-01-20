import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';

const DIcontainer = [
  LoaderComponent
];


@NgModule({
  declarations: [DIcontainer],
  imports: [
    CommonModule
  ],
  exports: [DIcontainer]
})
export class SharedModule { }
