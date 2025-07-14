import { TestBed } from '@angular/core/testing';

import { CustominterceptorServiceService } from './custominterceptor-service.service';

describe('CustominterceptorServiceService', () => {
  let service: CustominterceptorServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustominterceptorServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
