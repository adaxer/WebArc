import { Component, OnInit } from '@angular/core';
import { IProduct } from './product'
import { ProductFilterPipe } from './product-filter.pipe';
import { ProductService } from './product.service';
import { StarComponent } from '../shared/star.component';

@Component({
    selector: 'pm-products',
    templateUrl: 'app/products/product-list.component.html',
    styleUrls: ['app/products/product-list.component.css']
})
export class ProductListComponent implements OnInit {
    pageTitle: string = 'Products';
    showImage: boolean = false;
    imageWidth: number = 72;
    imageMargin: number = 2;
    pageFilter: string;
    products: IProduct[];
    errorMessage: string;

    constructor(private _productService: ProductService) {
    }

    onRatingClicked(message: string): void {
        this.pageTitle = 'Product List ' + message;
    }

    toggleImage(): void {
        this.showImage = !this.showImage;
    }

    ngOnInit(): void {
        this._productService.getProducts()
            .subscribe(
            p => this.products = p,
            e => this.errorMessage = <any>e);
    }
    // ngOnInit = (): void => {
    //     this.products = this._productService.getProducts();
    // }
}
