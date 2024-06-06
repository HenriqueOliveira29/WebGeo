import { TestBed } from '@angular/core/testing';

import { EstafetaService } from './estafeta.service';

describe('EstafetaService', () => {
  let service: EstafetaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EstafetaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
