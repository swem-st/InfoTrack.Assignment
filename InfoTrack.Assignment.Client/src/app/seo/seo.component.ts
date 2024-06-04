import { Component, OnInit } from '@angular/core';
import { SeoService } from './seo.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-seo',
  templateUrl: './seo.component.html',
  styleUrls: ['./seo.component.css']
})
export class SeoComponent implements OnInit {

  ngOnInit(): void { }


  searchForm = this.fb.group({
    searchTerm: ['', [Validators.required, Validators.maxLength(200)]],
    url: ['', [Validators.required, Validators.maxLength(200)]],
    searchEngine: [20, Validators.required],
  });


  searchTerm: string = '';
  url: string = '';
  results: string = '';
  searchEngine: string = '';
  searchEngines = [
    { value: 10, viewValue: 'Bing' },
    { value: 20, viewValue: 'Google' },
    { value: 30, viewValue: 'Yahoo' }
  ];


  constructor(private seoService: SeoService, private fb: FormBuilder, private snackBar: MatSnackBar) { }

  onSearch() {
    if (this.searchForm.valid) {
      const{ searchTerm, url, searchEngine } = this.searchForm.value;

      this.seoService.fetchSearchStatistics(searchTerm ?? '', url ?? '', searchEngine ?? 20).subscribe(
      (response) => {
        this.results = response;
      },
      (error) => {
        console.error('Error fetching search statistics', error);
        this.snackBar.open('Error fetching search statistics',
          'Close',
          {
            duration: 3000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
      }
    );
  }
}
}
