import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit {
  private hubConnection: HubConnection;

  nick: string | null;
  message = '';
  messages: string[] = [];

  constructor() {
    this.nick = window.prompt('Your name:', 'John');

    this.hubConnection = new HubConnectionBuilder()
      .withUrl(environment.messengerHubUrl)
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch((err) =>
        console.log('Error while establishing connection :(', err)
      );


    this.hubConnection.on('MemberJoined', (connectionId: string, username: string) => {
      let text = `Member joined with connection ${connectionId}! Hello ${username}`;
      
      this.messages.push(text);
    });

    this.hubConnection.on('ReceiveMessage', (message: string) => {
      this.messages.push(message);
      this.message = '';
    });
  }

  ngOnInit(): void {
    setTimeout(() => {
      this.hubConnection.invoke('JoinChannel').catch((err) => console.error(err));
    }, 2500);
  }

  sendMessageHandler(): void {
    this.hubConnection
      .invoke('SendMessage', this.message)
      .catch((err) => console.error(err));
  }
}
