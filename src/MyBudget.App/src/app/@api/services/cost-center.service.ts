/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { GetCostCenterByIdResponse } from '../models/get-cost-center-by-id-response';
import { RemoveCostCenterResponse } from '../models/remove-cost-center-response';
import { GetCostCentersResponse } from '../models/get-cost-centers-response';
import { CreateCostCenterResponse } from '../models/create-cost-center-response';
import { CreateCostCenterRequest } from '../models/create-cost-center-request';
import { UpdateCostCenterResponse } from '../models/update-cost-center-response';
import { UpdateCostCenterRequest } from '../models/update-cost-center-request';
import { GetCostCentersPageResponse } from '../models/get-cost-centers-page-response';
@Injectable({
  providedIn: 'root',
})
class CostCenterService extends __BaseService {
  static readonly getCostCenterByIdPath = '/api/CostCenter/{costCenterId}';
  static readonly removeCostCenterPath = '/api/CostCenter/{costCenterId}';
  static readonly getCostCentersPath = '/api/CostCenter';
  static readonly createCostCenterPath = '/api/CostCenter';
  static readonly updateCostCenterPath = '/api/CostCenter';
  static readonly getCostCentersPagePath = '/api/CostCenter/page/{pageSize}/{index}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Get CostCenter by id.
   *
   * Get CostCenter by id.
   * @param costCenterId undefined
   * @return Success
   */
  getCostCenterByIdResponse(costCenterId: string): __Observable<__StrictHttpResponse<GetCostCenterByIdResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/CostCenter/${encodeURIComponent(String(costCenterId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetCostCenterByIdResponse>;
      })
    );
  }
  /**
   * Get CostCenter by id.
   *
   * Get CostCenter by id.
   * @param costCenterId undefined
   * @return Success
   */
  getCostCenterById(costCenterId: string): __Observable<GetCostCenterByIdResponse> {
    return this.getCostCenterByIdResponse(costCenterId).pipe(
      __map(_r => _r.body as GetCostCenterByIdResponse)
    );
  }

  /**
   * Delete CostCenter.
   *
   * Delete CostCenter.
   * @param costCenterId undefined
   * @return Success
   */
  removeCostCenterResponse(costCenterId: string): __Observable<__StrictHttpResponse<RemoveCostCenterResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/CostCenter/${encodeURIComponent(String(costCenterId))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RemoveCostCenterResponse>;
      })
    );
  }
  /**
   * Delete CostCenter.
   *
   * Delete CostCenter.
   * @param costCenterId undefined
   * @return Success
   */
  removeCostCenter(costCenterId: string): __Observable<RemoveCostCenterResponse> {
    return this.removeCostCenterResponse(costCenterId).pipe(
      __map(_r => _r.body as RemoveCostCenterResponse)
    );
  }

  /**
   * Get CostCenters.
   *
   * Get CostCenters.
   * @return Success
   */
  getCostCentersResponse(): __Observable<__StrictHttpResponse<GetCostCentersResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/CostCenter`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetCostCentersResponse>;
      })
    );
  }
  /**
   * Get CostCenters.
   *
   * Get CostCenters.
   * @return Success
   */
  getCostCenters(): __Observable<GetCostCentersResponse> {
    return this.getCostCentersResponse().pipe(
      __map(_r => _r.body as GetCostCentersResponse)
    );
  }

  /**
   * Create CostCenter.
   *
   * Create CostCenter.
   * @param body undefined
   * @return Success
   */
  createCostCenterResponse(body?: CreateCostCenterRequest): __Observable<__StrictHttpResponse<CreateCostCenterResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/CostCenter`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<CreateCostCenterResponse>;
      })
    );
  }
  /**
   * Create CostCenter.
   *
   * Create CostCenter.
   * @param body undefined
   * @return Success
   */
  createCostCenter(body?: CreateCostCenterRequest): __Observable<CreateCostCenterResponse> {
    return this.createCostCenterResponse(body).pipe(
      __map(_r => _r.body as CreateCostCenterResponse)
    );
  }

  /**
   * Update CostCenter.
   *
   * Update CostCenter.
   * @param body undefined
   * @return Success
   */
  updateCostCenterResponse(body?: UpdateCostCenterRequest): __Observable<__StrictHttpResponse<UpdateCostCenterResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = body;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/CostCenter`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<UpdateCostCenterResponse>;
      })
    );
  }
  /**
   * Update CostCenter.
   *
   * Update CostCenter.
   * @param body undefined
   * @return Success
   */
  updateCostCenter(body?: UpdateCostCenterRequest): __Observable<UpdateCostCenterResponse> {
    return this.updateCostCenterResponse(body).pipe(
      __map(_r => _r.body as UpdateCostCenterResponse)
    );
  }

  /**
   * Get CostCenter Page.
   *
   * Get CostCenter Page.
   * @param params The `CostCenterService.GetCostCentersPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getCostCentersPageResponse(params: CostCenterService.GetCostCentersPageParams): __Observable<__StrictHttpResponse<GetCostCentersPageResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;


    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/CostCenter/page/${encodeURIComponent(String(params.pageSize))}/${encodeURIComponent(String(params.index))}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetCostCentersPageResponse>;
      })
    );
  }
  /**
   * Get CostCenter Page.
   *
   * Get CostCenter Page.
   * @param params The `CostCenterService.GetCostCentersPageParams` containing the following parameters:
   *
   * - `pageSize`:
   *
   * - `index`:
   *
   * @return Success
   */
  getCostCentersPage(params: CostCenterService.GetCostCentersPageParams): __Observable<GetCostCentersPageResponse> {
    return this.getCostCentersPageResponse(params).pipe(
      __map(_r => _r.body as GetCostCentersPageResponse)
    );
  }
}

module CostCenterService {

  /**
   * Parameters for getCostCentersPage
   */
  export interface GetCostCentersPageParams {
    pageSize: number;
    index: number;
  }
}

export { CostCenterService }
