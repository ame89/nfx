/*<FILE_LICENSE>
* NFX (.NET Framework Extension) Unistack Library
* Copyright 2003-2014 IT Adapter Inc / 2015 Aum Code LLC
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
</FILE_LICENSE>*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NFX;

namespace NFX.Web.Pay
{
  /// <summary>
  /// Represents account type because some pay services (i.e. Stripe) requires this info
  /// </summary>
  public enum AccountType { Individual, Corporation };

  /// <summary>
  /// Represents actual data for supplied account object.
  /// Data represented by this interface is ALWAYS TRANSITIVE in memory as 
  /// some fields are either never stored permanently (i.e. CVC) or ciphered in the store (account number)
  /// </summary>
  public interface IActualAccountData
  {
    Account Account { get; }

    string FirstName { get; }
    string MiddleName { get; }
    string LastName { get; }

    string AccountTitle { get; }

    AccountType AccountType { get; set; }

    bool HadSuccessfullTransactions { get; }
    string IssuerID { get; }
    string IssuerName { get; }
    string IssuerPhone { get; }
    string IssuerEMail { get; }
    string AccountNumber { get; }
    string RoutingNumber { get; }
    int CardExpirationYear { get; }
    int CardExpirationMonth { get; }
    string CardVC { get; }

    bool IsCard { get; }

    string BillingAddress1 { get; }
    string BillingAddress2 { get; }
    string BillingCity { get; }
    string BillingRegion { get; }
    string BillingPostalCode { get; }
    string BillingCountry { get; }

    string BillingPhone { get; }
    string BillingEmail { get; }


    string ShippingAddress1 { get; }
    string ShippingAddress2 { get; }
    string ShippingCity { get; }
    string ShippingRegion { get; }
    string ShippingPostalCode { get; }

    string ShippingPhone { get; }
    string ShippingEmail { get; }
  }

  public class ActualAccountData : IActualAccountData
  {
    public Account Account { get; set; }

    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }

    public string AccountTitle 
    { 
      get 
      {
        return string.Join(" ", new string[] { FirstName, MiddleName, LastName }.Where(s => s.IsNotNullOrWhiteSpace()));
      }
    }

    public AccountType AccountType { get; set; }
    
    public bool HadSuccessfullTransactions { get; set; }
    public string IssuerID { get; set; }
    public string IssuerName { get; set; }
    public string IssuerPhone { get; set; }
    public string IssuerEMail { get; set; }
    public string AccountNumber { get; set; }
    public string RoutingNumber { get; set; }
    public int CardExpirationYear { get; set; }
    public int CardExpirationMonth { get; set; }
    public string CardVC { get; set; }

    public bool IsCard { get { return RoutingNumber.IsNullOrWhiteSpace(); } }
    
    public string BillingAddress1 { get; set; }
    public string BillingAddress2 { get; set; }
    public string BillingCity { get; set; }
    public string BillingRegion { get; set; }
    public string BillingPostalCode { get; set; }
    public string BillingCountry { get; set; }
    
    public string BillingPhone { get; set; }
    public string BillingEmail { get; set; }

    
    public string ShippingAddress1 { get; set; }
    public string ShippingAddress2 { get; set; }
    public string ShippingCity { get; set; }
    public string ShippingRegion { get; set; }
    public string ShippingPostalCode { get; set; }
    
    public string ShippingPhone { get; set; }
    public string ShippingEmail { get; set; }
  }
}
