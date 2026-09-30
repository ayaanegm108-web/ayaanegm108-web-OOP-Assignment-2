using SrpLab;

Console.WriteLine("SrpLab — 10 intentional SRP violations (refactor me)");
Console.WriteLine("=================================================");

// 1. Ward
var beds = new BedRegistry();
var pager = new PagerAlertLog();
var admission = new WardAdmission(beds, new AcuityScorer(), pager);
var nowUtc = DateTime.UtcNow;
admission.Admit(1, "p-88", heartRate: 130, spo2: 89, nowUtc);
Console.WriteLine(new HandoffNoteFormatter().Format(1, beds.Find(1), nowUtc));
Console.WriteLine(string.Join(" | ", pager.Drain()));

// 2. Checkout
var basket = new CheckoutBasket();
basket.AddLine("SKU-1", 40m, 2);
basket.ApplyCouponText("SAVE10");
basket.EnableGiftWrap();
var pricing = new BasketPricing(new CouponDiscountRules(), new GiftWrapPolicy());
var grandTotal = pricing.GrandTotal(basket);
var auth = new PaymentAuthorizer().Authorize(grandTotal, "4242", basket.Lines.Count);
Console.WriteLine($"basket total={grandTotal} auth={auth}");

// 3. Support
var ticket = new SupportTicket("T-1", "cannot login", "prod is down for me", DateTimeOffset.UtcNow,
    new TicketPriorityClassifier());
var slaDeadline = new SlaDeadlineCalculator().Deadline(ticket);
Console.WriteLine(new PublicReplyWriter().Write(ticket, "Nora", slaDeadline));

// 4. Loan
var application = new LoanApplication(60_000m, 640, 4, HasCollateral: false);
var riskModel = new LoanRiskModel();
var riskScore = riskModel.RiskScore(application);
var isEligible = riskModel.IsEligible(application);
var documents = new RequiredDocumentsChecklist().For(application, isEligible);
Console.WriteLine(new DecisionLetterWriter().Write(application, "Omar", isEligible, riskScore, documents));

// 5. Course enrollment
var roster = new CourseRoster("SEF-101", capacity: 1);
Console.WriteLine(roster.Register("a@mail.com"));
Console.WriteLine(roster.Register("b@mail.com"));
Console.WriteLine(new WelcomePacketWriter().Write(roster, "b@mail.com", "Bea"));

// 6. Kitchen
var kitchen = new KitchenTicket();
kitchen.AddItem("Pasta", new[] { "wheat", "milk" }, 12);
const int openStations = 2;
var allergens = new AllergenDetector().Detect(kitchen);
var eta = new CookTimeEstimator().EstimateMinutes(kitchen, openStations, allergens.Count > 0);
Console.WriteLine(new ThermalTicketPrinter().Render(kitchen, 42, allergens, eta));

// 7. Subscription billing
var subscription = new Subscription("c-9", 99m, new DateOnly(2026, 9, 1), new DateOnly(2026, 10, 1));
subscription.RegisterFailedPayment();
var invoiceNumbers = new InvoiceNumberGenerator();
var amountDue = new ProrationCalculator().Prorate(subscription, subscription.PeriodStart);
Console.WriteLine(new DunningEmailWriter().Write(subscription, "Sara", new DateOnly(2026, 9, 20),
    amountDue, invoiceNumbers.Next(subscription.PeriodStart)));

// 8. Warehouse
var pick = new WarehousePickList();
pick.AddNeed("BOLT", "A", 3, 10, 7);
pick.AddNeed("NUT", "B", 1, 5, 5);
var allocations = new StockAllocator().Allocate(pick.Lines);
var stops = new WalkingPathPlanner().Plan(pick.Lines, allocations);
Console.WriteLine(new PickerScriptWriter().Write(stops, allocations));

// 9. Grade book
var grades = new GradeBook();
grades.Record("s1", 92);
grades.Record("s1", 88);
var results = new StudentResultCalculator(new GradeAverageCalculator(), new LetterGradePolicy(), new HonorRollPolicy());
Console.WriteLine(new TranscriptWriter().Write(results.Calculate(grades, "s1"), "Ali"));

// 10. Appointments
var scheduler = new AppointmentScheduler(new BusinessHours(new TimeOnly(9, 0), new TimeOnly(17, 0), 30));
var slot = scheduler.FindNextSlot(DateTimeOffset.Parse("2026-09-21T08:00:00Z"), 48);
if (slot is null) throw new InvalidOperationException("no slot");
scheduler.TryBook(slot.Value);
Console.WriteLine(new SmsReminderWriter().Write(slot.Value, "0100"));

Console.WriteLine("Done. Now split responsibilities — without breaking behavior.");