import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  form: FormGroup;

  results: string[] = [];

  constructor(private fb: FormBuilder) {
    this.form = fb.group({
      searchQuery: [''],
    });
  }

  ngOnInit(): void {
  }

  onChangeHandler(): void {
    this.results.push(this.form.value.searchQuery);
    console.log(this.results);
    this.form.reset();
  }

}
