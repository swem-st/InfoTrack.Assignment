import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SeoService {
  private apiUrl = 'https://localhost:7179/seo/fetch/search-statistic';

  constructor(private http: HttpClient) { }

  fetchSearchStatistics(searchTerm: string, url: string, searchEngine: number ): Observable<any> {
    const body = {
      searchEngine: searchEngine,
      url: url,
      searchTerm: searchTerm
    };
    return this.http.post<any>(this.apiUrl, body);
  }
}
