CREATE TABLE GroupOfClients
(
  GroupID INT NOT NULL,
  Name INT NOT NULL,
  Description INT NOT NULL,
  PRIMARY KEY (GroupID)
);

CREATE TABLE Risk
(
  RiskID INT NOT NULL,
  Name INT NOT NULL,
  Description INT NOT NULL,
  AverageProbability INT NOT NULL,
  PRIMARY KEY (RiskID)
);

CREATE TABLE Post
(
  PostID INT NOT NULL,
  Name INT NOT NULL,
  Requirements INT NOT NULL,
  Salary INT NOT NULL,
  Responsibilities INT NOT NULL,
  PRIMARY KEY (PostID)
);

CREATE TABLE Client
(
  ClientID INT NOT NULL,
  FullName INT NOT NULL,
  DateOfBirth INT NOT NULL,
  Gender INT NOT NULL,
  Address INT NOT NULL,
  Phone INT NOT NULL,
  PassportData INT NOT NULL,
  GroupID INT,
  PRIMARY KEY (ClientID),
  FOREIGN KEY (GroupID) REFERENCES GroupOfClients(GroupID)
);

CREATE TABLE TypeOfPolicy
(
  TypeOfPolicyID INT NOT NULL,
  Name INT NOT NULL,
  Description INT NOT NULL,
  Conditions INT NOT NULL,
  RiskID1 INT NOT NULL,
  RiskID2 INT NOT NULL,
  RiskID3 INT NOT NULL,
  PRIMARY KEY (TypeOfPolicyID),
  FOREIGN KEY (RiskID1) REFERENCES Risk(RiskID),
  FOREIGN KEY (RiskID2) REFERENCES Risk(RiskID),
  FOREIGN KEY (RiskID3) REFERENCES Risk(RiskID)
);

CREATE TABLE Employee
(
  EmployeeID INT NOT NULL,
  FullName INT NOT NULL,
  Age INT NOT NULL,
  Gender INT NOT NULL,
  Address INT NOT NULL,
  Phone INT NOT NULL,
  PassportData INT NOT NULL,
  PostID INT NOT NULL,
  PRIMARY KEY (EmployeeID),
  FOREIGN KEY (PostID) REFERENCES Post(PostID)
);

CREATE TABLE Policy
(
  PolicyID INT NOT NULL,
  DateOfStart INT NOT NULL,
  DateOfFinish INT NOT NULL,
  Cost INT NOT NULL,
  PaymentAmount INT NOT NULL,
  PaymentMark INT NOT NULL,
  MarkOfEnd INT NOT NULL,
  ClientID INT,
  TypeOfPolicyID INT NOT NULL,
  EmployeeID INT NOT NULL,
  PRIMARY KEY (PolicyID),
  FOREIGN KEY (ClientID) REFERENCES Client(ClientID),
  FOREIGN KEY (TypeOfPolicyID) REFERENCES TypeOfPolicy(TypeOfPolicyID),
  FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
);