import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdvertSelectionService {
  private selectedAdvertTitle = new BehaviorSubject<string>(''); // Başlangıç değeri boş string

  selectedAdvertTitle$ = this.selectedAdvertTitle.asObservable();

  selectAdvertTitle(title: string) {
    this.selectedAdvertTitle.next(title);
  }

}
