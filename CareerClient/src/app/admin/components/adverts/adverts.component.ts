import { Component } from '@angular/core';
import { HttpClientService } from '../../../services/common/http-client.service';

@Component({
  selector: 'app-adverts',
  templateUrl: './adverts.component.html',
  styleUrl: './adverts.component.scss'
})
export class AdvertsComponent {
  /**
   *
   */
  constructor(private httpClienService:HttpClientService) {
    
    
  }
  ngOnInit(): void{
    //Örnek Veri Getirme
    /*
    this.httpClienService.get({
      controller: "Category",
    }).subscribe(data => console.log(data));
    */


    //Örnek Veri Ekleme
    /*
    this.httpClienService.post({
        controller:"Category"
    },{
      name:"kalem",
      stock:100,
      price:100
    }).subscribe();
    */

   //Örnek Veri Silme
   /*
   this.httpClienService.delete({
    controller:"Category"
   },"4e796cd6-e868-4002-9182-d0dc5f102c97").subscribe();
    */
  }
}
