import { Component } from '@angular/core';
import { AppUserAuth } from '../security/app-user-auth';
import { SecurityService } from '../shared/security/security.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'header',
  imports: [CommonModule, RouterModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  securityObject: AppUserAuth | undefined;

  constructor(private securityService: SecurityService) {
    this.securityObject = securityService.securityObject;
  }

  logout(): void {
    this.securityService.logout(); // securityObject.init() everything gets reset
    this.securityObject = this.securityService.securityObject; // in sync
    localStorage.removeItem('AuthObject'); // When logged out, clear this information.
  }
}
