import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
  selector: 'app-crypter',
  templateUrl: './crypter.component.html',
  styleUrls: ['./crypter.component.css']
})
export class CrypterComponent implements OnInit {
  public hubConnection: HubConnection;

  constructor() { 
  }

  ngOnInit() {
    const builder = new HubConnectionBuilder();

    this.hubConnection = builder.withUrl("http://localhost:5000" + '/hubs/rsa').build();

    this.hubConnection.on('SendKeys', (publicKey, privateKey) => {
     // TODO
    });

    this.hubConnection.start().then(_ => {
      this.hubConnection.invoke("Connected");
    });
  }

}
