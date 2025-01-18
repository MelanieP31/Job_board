import { TestBed } from '@angular/core/testing';

import { JobOfferService } from './services';

describe('JobOfferService', () => {
  let service: JobOfferService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JobOfferService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
