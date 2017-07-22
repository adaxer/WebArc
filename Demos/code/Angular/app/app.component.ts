import { Component } from '@angular/core';
import { Route } from '@angular/router';

import { WelcomeComponent } from './home/welcome.component';
import { ProductListComponent } from './products/product-list.component';
import { ProductService } from './products/product.service';
import 'rxjs/Rx';

@Component({
    selector: 'pm-app',
    template: `
    <div>
        <nav class='navbar navbar-default'>
            <div class='container-fluid'>
                <a class='navbar-brand'>{{pageTitle}}</a>
                <ul class='nav navbar-nav navbar-collapsed'>
                    <li><a [routerLink]="['/welcome']">Home</a></li>
                    <li><a [routerLink]="['/products']">Product List</a></li>
                </ul>
            </div>
        </nav>
        <div class='container'>
            <router-outlet></router-outlet>
        </div>
     </div>
`,
    entryComponents: [ProductListComponent],
    providers: [ProductService]

})
export class AppComponent {
    pageTitle: string = 'Acme Shopping experience';
}
