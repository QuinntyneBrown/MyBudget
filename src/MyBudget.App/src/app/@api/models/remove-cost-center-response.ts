/* tslint:disable */
import { CostCenterDto } from './cost-center-dto';
export interface RemoveCostCenterResponse {
  costCenter?: CostCenterDto;
  validationErrors?: Array<string>;
}
