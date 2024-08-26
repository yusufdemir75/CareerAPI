import { Component } from '@angular/core';
import { AlertifyService, MessageType } from '../../services/admin/alertify.service';


@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss'
})
export class LayoutComponent {
    constructor(private alertify: AlertifyService){}

    ngOnInit(): void{
      this.alertify.message("Merhaba", MessageType.Error)
    }
}
