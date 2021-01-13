import { TestBed } from '@angular/core/testing';

import { RserviceService } from './rservice.service';

describe('RserviceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RserviceService = TestBed.get(RserviceService);
    expect(service).toBeTruthy();
  });
});
