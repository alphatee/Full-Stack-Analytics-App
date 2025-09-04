import { Component } from '@angular/core';
import { AppUser } from '../security/app-user';
import { AppUserAuth } from '../security/app-user-auth';
import { SecurityService } from '../shared/security/security.service';
import { MessageService } from '../shared/messaging/message.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  user: AppUser = new AppUser();
  securityObject: AppUserAuth | undefined;
  returnUrl: string | undefined;

  constructor(
    private securityService: SecurityService,
    private msgService: MessageService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParamMap.get('returnUrl')!;
  }

  login() {
    this.msgService.clearAll(); // clear any messages being displayed

    this.securityObject?.init(); // like brand new authentication, 'normal' state for new people to login

    // BELOW IS NO LONGER SUFFICIENT
    /*this.securityService.login(this.user)  // pass in bound user object, username and password and compare to the names in switch statement.
    .subscribe(resp => this.securityObject = resp); */

    // generate our securityObject, then that is what we subscribe too
    // then we take that observable and place into the this.securityObject
    // go from this component to html line "<label>{{securityObject | json}}</label>"
    // meaning to display that label as JSON!

    // BELOW IS SUFFICIENT
    this.securityService
      .login(this.user) // pass in bound user object, username and password and compare to the names in switch statement.
      .subscribe((resp) => {
        // the below is broswer memory to know if someone is still logged in
        localStorage.setItem('AuthObject', JSON.stringify(resp)); // we take our authobj [KEY], and JSON stringify it, then store in localStorage
        this.securityObject = resp; // stores in localStorage in the browser
        if (this.returnUrl) {
          this.router.navigateByUrl(this.returnUrl);
        } else {
          this.router.navigate(['/traveldetails']);
        }
        this.user = new AppUser(); // clear the form by resetting the user
        this.snackBar.open('Logged In Successfully!', '', {
          duration: 2500, // Optional: duration in milliseconds
          panelClass: ['cdk-global-overlay-wrapper']
      });
      });
  }
}
