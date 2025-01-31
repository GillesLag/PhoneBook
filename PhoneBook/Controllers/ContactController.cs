using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook.Controllers;

public class ContactController
{
    private readonly PhoneBookContext _context;

    public ContactController(PhoneBookContext context)
    {
        _context = context;
    }
    public int AddContact(Contact contact)
    {
        _context.Contacts.Add(contact);
        return _context.SaveChanges();
    }

    public int RemoveContact(int id)
    {
        Contact contact = _context.Contacts.Find(id);

        _context.Contacts.Remove(contact);

        return _context.SaveChanges();
    }

    public int UpdateContact(Contact contact)
    {
        var entity = _context.Contacts.Find(contact.Id);

        if (entity != null)
        {
            _context.Contacts.Update(contact);
        }

        return _context.SaveChanges();
    }

    public List<Contact> GetContacts()
    {
        return _context.Contacts.ToList();
    }
}
