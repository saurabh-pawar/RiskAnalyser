# RiskAnalyser
This is an application which helps analyse risks related to betting. It helps identify unusual customers and high risk bets based on the rules set by the business.

## Synopsis

In a betting company, there is always a need to identify risks so that future results can be predicted and appropriate strategies can be executed. This Risk Analyser application helps to identify unsual customers and bets which seem to have high risk.

## Code Example

```c# 
IRiskAnalyser 
```
interface provides functionality to identify unsual customers and risky bets

You need to pass Customer Model to most of the functions.

```c# 
public class Customer
{
	public int Id { get; set; }
	public List<Bet> SettledBets { get; set; }
	public List<Bet> UnSettledBets { get; set; }
}

 public class Bet
{
	public int CustomerId { get; set; }
	public int EventId { get; set; }
	public int ParticipantId { get; set; }
	public int Stake { get; set; }
	public int ToWin { get; set; }
	public int Win { get; set; }

}	
```

Sample Function : 
```c#
   List<Customer> GetUnusualCustomers(List<Customer> customers);
```

## Installation

You need VisualStudio to compile and run the application. Currenly there is no UI for the application. It is in development phase. However you can use the RiskAnalyser.Application class library project and create your own UI.

## API Reference

### RiskAnalyser Functions :
##### GetUnusualCustomers
Returns customers which have win percentage more than 60%.
``` c#
    List<Customer> GetUnusualCustomers(List<Customer> customers);
```

##### GetUnSettledBetsFromUnusualCustomers
Returns all unsettled bets from all customers who have win percentage more than 60%
``` c#
    List<Bet> GetUnSettledBetsFromUnusualCustomers(List<Customer> customers);
```

##### GetHigherStakeBets
Returns all unsettled bets from all customers where bet stake is more than (customers average bet amount * specified stakeRate).
``` c#
    List<Bet> GetHigherStakeBets(List<Customer> customers, int stakeRate);
```

##### GetBigWinBets
Returns all unsettled bets from all customers where winning amount of the bet is more than the specified win margin
``` c#
    List<Bet> GetBigWinBets(List<Customer> customers, int winMargin);
```


### CustomerRepository Functions :
Reads the information from the 2 data sources, creates customers and returns them.
```c#
        List<Customer> GetAllCustomers(string settledDataSource, string unSettledDataSource);
```

## Extending application to identify new risks.
Implement either 
```c#
ICustomerRule
```
or
```c#
IBetRule
```
depending on you risk rule.

## Tests

All tests are written using xUnit. You can run them using VisualStudio. 


