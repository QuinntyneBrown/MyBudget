/* tslint:disable */
import { CostCenterDto } from './cost-center-dto';
export interface GetCostCentersResponse {
  costCenters?: Array<CostCenterDto>;
  validationErrors?: Array<string>;
}
