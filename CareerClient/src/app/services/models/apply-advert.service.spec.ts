import { TestBed } from '@angular/core/testing';

import { ApplyAdvertService } from './apply-advert.service';

describe('ApplyAdvertService', () => {
  let service: ApplyAdvertService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApplyAdvertService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
