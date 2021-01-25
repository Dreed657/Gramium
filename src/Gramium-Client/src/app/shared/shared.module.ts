import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { PostComponent } from './post/post.component';
import { HttpClientModule } from '@angular/common/http';
import { TimeDiffPipe } from './pipes/time-diff.pipe';
import { CreateComponent } from './create/create.component';
import { ReactiveFormsModule } from '@angular/forms';

import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

const DIcontainer = [
  LoaderComponent,
  PostComponent,
  TimeDiffPipe,
  CreateComponent
];

@NgModule({
  declarations: [DIcontainer],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    FontAwesomeModule,
    MatMenuModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule
  ],
  exports: [DIcontainer]
})
export class SharedModule { }
