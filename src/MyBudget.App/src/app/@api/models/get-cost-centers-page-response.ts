/* tslint:disable */
import { CostCenterDto } from './cost-center-dto';
export interface GetCostCentersPageResponse {
  entities?: Array<CostCenterDto>;
  length?: number;
  validationErrors?: Array<string>;
}
