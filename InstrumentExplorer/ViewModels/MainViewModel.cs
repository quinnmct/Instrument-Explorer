using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace InstrumentExplorer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Instruments = new ObservableCollection<InstrumentViewModel>();

            this.LoadData();
        }

        

        //A list of all chosen Instruments
        private ObservableCollection<InstrumentViewModel> instruments = new ObservableCollection<InstrumentViewModel>();
        public ObservableCollection<InstrumentViewModel> Instruments
        {
            get
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("SavedInstruments"))
                {
                    return (ObservableCollection<InstrumentViewModel>)IsolatedStorageSettings.ApplicationSettings["SavedInstruments"];
                }
                else
                {
                    return instruments;
                }
            }
            set
            {
                if (value != instruments)
                {
                    instruments = value;
                    NotifyPropertyChanged("Instruments");
                }
            }
        }
        //curremntly selected instrument
        public InstrumentViewModel SelectedInstrument {get; set;}



        public bool IsDataLoaded
        { get; private set; }

        private void LoadData()
        {
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Vibraphone",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                    {new ArtistViewModel(){Name="Bobby Hutcherson"}}),
                Description = "A percussion idiophone developed in the 1920's, used much in jazz music." +
                " It consists of metal bars arranged in the manner of a piano keyboard, and it is sounded" +
                " by means of soft mallets. It looks similar to a marimba, only with metal bars.",
                InstImage = new BitmapImage(new Uri("/Images/vibraphone2.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Tuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Guitar",CountryOfOrigin = "Spain",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Jimi Hendrix"},
                    new ArtistViewModel(){Name="B. B. King"},
                    new ArtistViewModel(){Name="Eric Clapton"}
                }),
                Description = "A plucked stringed instrument extremely popular today, especially among folk and rock "+
                "musicians. The guitar has six strings, frets (usually 19), a shape something between pear-shaped and "+
                "a figure eight, a round sound hole, and usually a flat-backed soundbox. The standard tuning "+
                "of the strings is E A D G B E.",
                InstImage = new BitmapImage(new Uri("/Images/12-string-guitar.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Saxophone",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                    {new ArtistViewModel(){Name="John Coltrane"}}),
                Description = "A family of wind instruments invented by Adolphe Sax in 1840. The saxophone has a single "+
                "reed similar to a clarinet, but is made of brass; the bore is tapered; the fingering system is based on "+
                "that of the oboe. The saxophone has become a popular band instrument, and occasionally is used in the "+
                "orchestra. Where the saxophone has earned the most fame, however, is in jazz and rock music.",
                InstImage = new BitmapImage(new Uri("/Images/saxophone.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory ="Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Piano",CountryOfOrigin = "Italy",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Ray Charles"},
                    new ArtistViewModel(){Name="Ludwig van Beethoven"},
                    new ArtistViewModel(){Name="Wolfgang Mozart"}
                }),
                Description = "A modern keyboard instrument that produces sounds by hammers striking strings. These hammers are "+
                "activated by keys, depressed by the performer's fingers. The piano is equipped with a pedal that controls the "+
                "dampers which stop the vibration of the strings. The piano is an extremely popular instrument in Classical, "+
                "Romantic, Post-Romantic, Modern, Jazz, Pop, Rock, and Folk music.",
                InstImage = new BitmapImage(new Uri("/Images/piano.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Keyboard"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Accordion",CountryOfOrigin = "Germany",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Pietro Frosini"}
                }),
                Description = "The accordion is a portable wind instrument consisting of two reed organs connected by a folding "+
                "bellows. Expanding and contracting the bellows provides air to vibrate the reed organs producing the sounds. It "+
                "is also known as a squeeze box because of this expanding and contracting of the bellows. There is a keyboard on "+
                "the right side for playing melody notes and buttons on the left to sound bass notes and full chords. A second type "+
                "of accordion contains buttons on both left and right sides which includes the concertina and Bandoneon.",
                InstImage = new BitmapImage(new Uri("/Images/accordion.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Keyboard"
            });

            instruments.Add(new InstrumentViewModel()
            {
                Name = "Hurdy Gurdy",CountryOfOrigin = "Middle Ages",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                    {new ArtistViewModel(){Name="Patrick Bouffard"}}),
                Description = "Also called 'organistrum', the hurdy gurdy is a Medieval instrument that is still used in some parts of "+
                "Europe as a folk instrument. It has the shape of a viol, but it is bowed mechanically, and has only four strings, two "+
                "of which act as drones. The melody strings are 'bowed' by a wheel. There is also a system of keys which, when pressed, "+
                "activate a mechanism which stops the strings at different places, thus producing the tune.",
                InstImage = new BitmapImage(new Uri("/Images/HurdyGurdy.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Theremin",
                CountryOfOrigin = "Russia",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Clara Rockmore"}
                }),
                Description = "Invented by Leo Theremin in the 1920's, this instrument generates electronic pitches. The pitchs and volume " +
                "are controled by the proximity of the player's hands to metal protrusions associated with each. Thus, moving the hands closer " +
                "to or farther away from the pitch protrusion will result in a higher or lower pitch and moving the hands closer to or farther " +
                "away from the volume protrusion will result in a louder or softer volume. The somewhat eerie quality of the theremin can be " +
                "heard in many movie soundtracks in the sci-fi and horror genre in the 1940's, 1950's, and 1960's.",
                InstImage = new BitmapImage(new Uri("/Images/theremin.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Electrophones",
                HbsSubcategory = "Electronic"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Bassoon",CountryOfOrigin = "France",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                    {new ArtistViewModel(){Name="Archie Camden"}}),
                Description = "The bassoon is a double reed wind instrument with a conical bore. The pitch of the bassoon can be altered by adjusting "+
                "the position of the bocal in its receiver. By pulling the bocal out you can lengthen the instrument which will lower the pitch "+
                "slightly or by pushing it in you can shorten the instrument which will raise the pitch slightly. The bassoon rivals the oboe by the "+
                "virtue of how well the instrument can produce attacks and staccato passages but the tone of the is less nasal. The bassoon, like the "+
                "oboe, performs lyric melodies excellently. The unique sound of the bassoon makes it ideal to be used for comical or grotesque effects.",
                InstImage = new BitmapImage(new Uri("/Images/Bassoon.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory ="Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Clavichord",CountryOfOrigin = "Germany",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Johann Sebastian Bach"},
                    new ArtistViewModel(){Name="Richard Troeger"}
                }),
                Description = "A small keyboard instrument popular in the Renaissance, which is distinguished from other keyboard instruments of the era "+
                "by the fact that its strings are struck rather than plucked. Because the strings are sounded only by being struck, the volume of the clavichord "+
                "is very soft. It is one of the simplest keyboard instruments, built into a rectangular frame in which the keys and attached levers are fixed; "+
                "the levers strike the strings by means of small, metal hammers.",
                InstImage = new BitmapImage(new Uri("/Images/clavichord.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Keyboard"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Electric Bass",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Les Claypool"},
                    new ArtistViewModel(){Name="Flea"},
                    new ArtistViewModel(){Name="Paul McCartney"}
                }),
                Description = "The bass guitar (also called electric bass, or simply bass) is a stringed instrument played primarily with the fingers or thumb, by "+
                "plucking, slapping, popping, tapping, thumping, or picking with a plectrum. The bass guitar is similar in appearance and construction to an electric "+
                "guitar, but with a longer neck and scale length, and four to six strings or courses. The four-string bass—by far the most common—is "+
                "usually tuned the same as the double bass,",
                InstImage = new BitmapImage(new Uri("/Images/bass_guitar.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Xylophone",CountryOfOrigin = "Southeast Asia",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                    {new ArtistViewModel(){Name="George Hamilton Green"}}),
                Description = "A percussion instrument consisting of a row of chromatically tuned wooden bars, arranged in the manner of a piano keyboard. The bars are "+
                "supported by a wooden frame over resonator tubes and they are sounded by being struck with mallets. Currently, the standard xylophone has a range of "+
                "three-and-a-half octaves (f to c4). Commercial sizes can have as few as three octaves and as many as five octaves. The xylophone sounds one octaves higher than the written note.",
                InstImage = new BitmapImage(new Uri("/Images/xylophone.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Tuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Snare Drum",CountryOfOrigin = "Middle Ages",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Jimi Hendrix"},
                    new ArtistViewModel(){Name="B. B. King"},
                    new ArtistViewModel(){Name="Eric Clapton"}
                }),
                Description = "A drum common in orchestral, band, and jazz music with two heads. It is named after the 'snares' or rawhide strings stretched across the lower head.",
                InstImage = new BitmapImage(new Uri("/Images/snaredrum.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Trumpet",CountryOfOrigin = "Ancient Egypt",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                    {new ArtistViewModel(){Name="Louis Armstrong"}}),
                Description = "A family of brass instruments with a cylindrical bore, valves, and a cup mouthpiece producing a clear, bright "+
                "tone. Three valves are used to make the instrument fully chromatic. Some models have a fourth valve to adjust for inherent "+
                "intonation problems of the instrument. A trigger mechanism is sometimes added to the the first or third valve tuning slide "+
                "that is used to provide a way for the performer to fix the intonation problems with certain valve combinations. Sound is produced "+
                "(as in most brass instruments) by the vibration of the performers lips. Three valves are used to make the instrument fully chromatic.",
                InstImage = new BitmapImage(new Uri("/Images/trumpet.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory ="Brass"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Organ",CountryOfOrigin = "Greece",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="John Medeski"}
                }),
                Description = "A keyboard instrument that is sounded by air moving through pipes. The pipe organ usually has several manuals as well as "+
                "pedals that control the air flow through combinations of pipes. A rank of pipes constitues one stop and consists of a row of pipes, one "+
                "for each key on the keyboard. Organ pipes come in a variety of sizes, shapes, materials, and methods of setting the air columns to vibrate. "+
                "The pipes can range in size from a quarter-inch in length to over 32 feet with the shorter pipes creating the higher pitches and the larger "+
                "pipes creating the lowest pitches. Organ pipes can be any shape from round to square, conical to cylindrical, or from straight to curved. "+
                "The differing shapes provide a variety of tone colors.",
                InstImage = new BitmapImage(new Uri("/Images/organ.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Keyboard"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Bongos",CountryOfOrigin = "Cuba",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Jack Costanzo"}
                }),
                Description = "A pair of permanently attached small single-headed drums the larger of which is tuned about fifth below the smaller drum. The "+
                "bongos are of Afro-Cuban origin and are widely used in the popular music of Latin America. The bongos "+
                "were widely popular among the beatnik culture of the 1950's in America.",
                InstImage = new BitmapImage(new Uri("/Images/Bongos.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Horn",CountryOfOrigin = "Germany",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Radek Baborak"},
                    new ArtistViewModel(){Name="Hermann Baumann"}
                }),
                Description = "An ancient wind instrument, originally made from animal horn, metal, or wood. In the Medieval and Renaissance eras, the horn "+
                "was used to signal in battles and in hunts. The horn gradually evolved through a series of transformations: the horn for hunting became spiraled "+
                "so its length would not interfere with its mobility, this natural horn became more refined and found its way into the early Classical orchestra "+
                "as a character instrument, implying military or hunting scenes. Eventually crooks, and then valves were invented for the horn, enabling it "+
                "to be fully chromatic. In America, it is often referred to as the French horn.",
                InstImage = new BitmapImage(new Uri("/Images/Horn.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Brass"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Trombone",CountryOfOrigin = "Italy",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Arthur Pryor"},
                    new ArtistViewModel(){Name="Al Grey"}
                }),
                Description = "A family of brass instruments with a cylindrical bore and a slide rather than valves. The slide allows the performer to lengthen "+
                "or shorten the length of tubing in the instrument, thus allowing the harmonic series to be altered, making the instrument fully chromatic. Sound "+
                "is produced (as in most brass instruments) by the vibration of the performers lips. As the performer moves the slide out, the length of the tubing "+
                "is increased which lowers the pitch being sounded.",
                InstImage = new BitmapImage(new Uri("/Images/Trombone.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Brass"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Euphonium",CountryOfOrigin = "England",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="David Childs"}
                }),
                Description = "The concertmaster Sommer of Weimar designed the euphonium in 1843, which was a wide-bored valved bugle in the baritone range. This "+
                "instrument was then called the Euphonion. A brass instrument of the tuba family, smaller and higher in pitch than a tuba, with a range of B-flat "+
                "below the bass clef to B-flat in the treble clef. Sound is produced with the euphonium by the performer vibrating his/her lips against the mouthpiece. "+
                "A very mellow and smooth tone is produced from the instrument without the pitch problems that occurred and plagued the Wagner tubas, but the euphonium "+
                "is only used to replace the tenor tuba.",
                InstImage = new BitmapImage(new Uri("/Images/Euphonium.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Brass"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Sousaphone",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Damon 'Tuba Gooding Jr.' Bryson"}
                }),
                Description = "The sousaphone is basically a tuba that coils around the body with a flared bell that faces forward. As such, it is similar to the tuba in "+
                "how it is played. The main difference is the sousaphone wraps around the performer's body to make the instrument easier to carry in marching bands. It is "+
                "It is made of the same brass material and can also be silver plated like a tuba. Many of the popular models are made of a fiberglass material that make it "+
                "much lighter in weight, designed for more comfort when carried for long periods. Most sousaphones have only three valves.",
                InstImage = new BitmapImage(new Uri("/Images/Sousaphone.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Brass"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Oboe",CountryOfOrigin = "France",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Adolf Rzepko"},
                    new ArtistViewModel(){Name="Albrecht Mayer"}
                }),
                Description = "The oboe is said to have the most unique 'voice' out of all the woodwinds. It has a warm, reedy, almost squawking sound. The pitch of the oboe is "+
                "easily 'lipped' higher or lower by the player, and a well-trained oboist is able to play long passages and long notes in a single breath due to the nature of the "+
                "instrument. Sensitivity of the reed makes the oboe a very taxing instrument to play. The breath control required calls for an oboist to have frequent rest periods.",
                InstImage = new BitmapImage(new Uri("/Images/Oboe.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Balafon",CountryOfOrigin = "West Africa",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Modibo Diabaté"}
                }),
                Description = "The balafon (bala, balaphone) is a resonated frame, wooden keyed percussion idiophone of West Africa; part of the idiophone family of tuned percussion "+
                "instruments that includes the xylophone, marimba, glockenspiel, and the vibraphone. Sound is produced by striking the tuned wooden keys with two padded sticks.",
                InstImage = new BitmapImage(new Uri("/Images/Balafon.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Tuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Kalimba",CountryOfOrigin = "West Africa",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Ephat Mujuru"}
                }),
                Description = "The thumb piano or kalimba is an African musical instrument, a type of plucked idiophone common throughout Sub-Saharan Africa. Also known as a 'sansa'"+
                "and 'mbira', it is popular throughout central, western and eastern Africa. The kalimba is played by holding the instrument in the hands and plucking the tines with the thumbs.",
                InstImage = new BitmapImage(new Uri("/Images/Kalimba.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Lamellophone"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Djembe",CountryOfOrigin = "West Africa",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Leon Mobely"}
                }),
                Description = "A djembe is a rope-tuned skin-covered goblet drum played with bare hands, originally from West Africa. According to the Bamana people in Mali, the name of the "+
                "djembe comes from the saying 'Anke djé, anke bé' which translates to 'everyone gather together in peace' and defines the drum's purpose. The djembe has a body (or shell) carved "+
                "of hardwood and a drumhead made of untreated (not limed) rawhide, most commonly made from goatskin. The djembe can produce a wide variety of sounds, making it a most versatile "+
                "drum. The drum is very loud, allowing it to be heard clearly as a solo instrument over a large percussion ensemble. The Malinké people "+
                "say that a skilled drummer is one who 'can make the djembe talk', meaning that the player can tell an emotional story.",
                InstImage = new BitmapImage(new Uri("/Images/Djembe.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Goblet Drum"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Cajon",CountryOfOrigin = "Peru",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Mario Cortes"}
                }),
                Description = "A cajón is a six sided, box-shaped percussion instrument originally from Perú, played by slapping the front or rear faces (generally thin plywood) with the hands,"+
                " fingers, or sometimes various implements such as brushes, mallets, or sticks.",
                InstImage = new BitmapImage(new Uri("/Images/Cajon.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Drum Kit",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Neil Peart"}
                }),
                Description = "A drummer in a rock or jazz band usually plays a 'kit' (sometimes refered to as a drum set) or a specific group of non-pitched percussion instruments. The usual "+
                "kit consists of the following instruments: kick drum, snare drum, hi-hat, tom-toms, floor tom, ride cymbal, and crash cymbal.",
                InstImage = new BitmapImage(new Uri("/Images/DrumSet.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Rhodes Piano",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Donald Fagen"}
                }),
                Description = "The Rhodes piano is an electro-mechanical piano, invented by Harold Rhodes during the 1950s. As a member of the electrophone sub-group of percussion instruments, "+
                "it employs a piano-like keyboard with hammers that hit small metal tines, amplified by electromagnetic pickups. A 2001 New York Times article described the instrument as 'a "+
                "pianistic counterpart to the electric guitar' having a 'shimmering, ethereal sound.'",
                InstImage = new BitmapImage(new Uri("/Images/Rhodes.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Electrophones",HbsSubcategory = "Electronic"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Marimba",CountryOfOrigin = "South Africa",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Keiko Abe"}
                }),
                Description = "Percussion instrument of African and Latin American origin. The modern marimba is a mellower version of the xylophone. Versions of the marimba can have a range "+
                "of up to seven octaves, but the modern standard is four octaves (c to c4) or four-and-a-third octaves (A to c4).Notes played on the marimba sound in the same octave as the "+
                "written notation.",
                InstImage = new BitmapImage(new Uri("/Images/Marimba.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Tuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Hang Drum",CountryOfOrigin = "Switzerland",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Daniel Waples"}
                }),
                Description = "The instrument is constructed from two half-shells of deep drawn, nitrided steel sheet glued together at the rim leaving the inside hollow and creating a distinct "+
                "'UFO shape'. The top ('Ding') side has a center 'note' hammered into it and seven or eight 'tone fields' hammered around the center. The bottom ('Gu') is a plain surface that "+
                "has a rolled hole in the center with a tuned note that can be created when the rim is struck.",
                InstImage = new BitmapImage(new Uri("/Images/Hang.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Tuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Clarinet",CountryOfOrigin = "Germany",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Anton Stadler"},
                    new ArtistViewModel(){Name="Squidward"}
                }),
                Description = "The instrument is constructed from two half-shells of deep drawn, nitrided steel sheet glued together at the rim leaving the inside hollow and creating a distinct "+
                "'UFO shape'. The top ('Ding') side has a center 'note' hammered into it and seven or eight 'tone fields' hammered around the center. The bottom ('Gu') is a plain surface that "+
                "has a rolled hole in the center with a tuned note that can be created when the rim is struck.",
                InstImage = new BitmapImage(new Uri("/Images/Clarinet.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Contrabassoon",CountryOfOrigin = "Germany",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Susan Nigro"}
                }),
                Description = "The contrabassoon, also known as the double bassoon or bass bassoon, is a larger version of the bassoon, sounding an octave lower. Its technique is similar to its "+
                "smaller cousin, with a few notable differences. The reed is considerably larger, at 65–75 mm in total length (and 20mm wide) as compared to 53–58 mm for most bassoon reeds. The "+
                "large blades allow ample vibration that produces the low register of the instrument.",
                InstImage = new BitmapImage(new Uri("/Images/Contrabassoon.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Tuba",CountryOfOrigin = "Germany",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Tommy Johnson"}
                }),
                Description = "The tuba is the largest and lowest-pitched brass instrument. Sound is produced by vibrating or 'buzzing' the lips into a large cupped mouthpiece. It first appeared "+
                "in the mid 19th-century, making it one of the newest instruments in the modern orchestra and concert band. The tuba largely replaced the ophicleide. Tuba is Latin for trumpet "+
                "or horn. The horn referred to would most likely resemble what is known as a baroque trumpet.",
                InstImage = new BitmapImage(new Uri("/Images/Tuba.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Brass"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Sitar",CountryOfOrigin = "India",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Ravi Shankar"}
                }),
                Description = "The sitar is a plucked stringed instrument used mainly in Hindustani music and Indian classical music. The instrument descended from long-necked lutes taken to "+
                "North India from Central Asia and is also believed to be influenced by the Veena. The sitar flourished in the 16th and 17th centuries and arrived at its present form in the "+
                "18th century Mughal period. It derives its distinctive timbre and resonance from sympathetic strings, bridge design, a long hollow neck and a gourd resonating chamber.",
                InstImage = new BitmapImage(new Uri("/Images/Sitar.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Harmonium",CountryOfOrigin = "France",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Shankar Jaikishan"}
                }),
                Description = "a pump organ in which the notes are produced by air driven through metal reeds by foot or hand operated bellows.",
                InstImage = new BitmapImage(new Uri("/Images/Harmonium.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Keyboard"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Ukelele",CountryOfOrigin = "Portugal",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A small guitar with four strings of Portuguese origin. It became popular in the South Pacific islands and by the early 1900's was a staple in many of these "+
                "cultures including Hawaii. Because the ukelele was portable, small, and light, cheap, easily played and simply tuned, it became a popular instrument in the United States "+
                "for accompanying folk songs after World War I.",
                InstImage = new BitmapImage(new Uri("/Images/Ukelele.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
             instruments.Add(new InstrumentViewModel()
            {
                Name = "Harpsichord",CountryOfOrigin = "Middle Ages",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "Early stringed keyboard instrument that produced tones by means of plucking strings with quills rather than by striking them with hammers, as in the modern "+
                "piano. The range of the harpsichord is generally about four octaves; it was most popular in the Renaissance and Baroque eras, in the classical era it was eclipsed by the piano.",
                InstImage = new BitmapImage(new Uri("/Images/harpsichord.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Keyboard"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Harp",CountryOfOrigin = "Mesopotamia",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A plucked stringed instrument of ancient origin, the modern orchestral harp has a somewhat triangular frame with forty-seven strings, encompassing a range of "+
                "C' to g''''. The harp is diatonic, but has a system of pedals which allow the key to be changed by changing the tuning of certain notes by up to two semitones. The harp "+
                "has a pillar, which helps support the tension of the strings. The pillar is attached to the neck at the top, and to the soundboard at the base, which is in turn connected "+
                "to the strings. The soundboard is connected at the top to the neck of the instrument, where the action plates are positioned.",
                InstImage = new BitmapImage(new Uri("/Images/harp.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Balalaika",CountryOfOrigin = "Russia",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A folk instrument popular in Russia, the balalaika is related to the lute, with a long, fretted neck, a triangular body, "+
                "and three strings. This instrument is known by the same name in most languanges.",
                InstImage = new BitmapImage(new Uri("/Images/balalaika.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Charango",CountryOfOrigin = "Peru",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A folk instrument originating in South America born out of contact between the Spaniards and the indigenous people. It is mainly used by peoples of the Andes (Bolivia, "+
                "Peru, Ecuador, etc). Classified as a 'fretted lute', the instrument is usually made from wood and the soundbox made from the shell of an armadillo. It has 5 pairs of "+
                "strings with the 3rd and 5th being in octaves. It is played in a style similar to some forms of flamenco guitar; rapid strumming with intricate rhythmic "+
                "patterns. Other instruments of the Andes include the Zampoña and Quena.",
                InstImage = new BitmapImage(new Uri("/Images/charango.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Lute",CountryOfOrigin = "Middle Ages",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "An instrument popular in the Medieval and Renaissance eras. The lute is a plucked string instrument of the guitar family, it has a short, fretted neck, a "+
                "rounded back, and a large body something between oval- and pear-shaped. The number of strings is variable, as is the size, but in the Renaissance, lutes with six courses "+
                "of strings tuned in A or G became standard. The lute enjoyed immense popularity in the Renaissance, partially due to its beautiful tone, its portability, "+
                "and its aptitude for accompanying the voice.",
                InstImage = new BitmapImage(new Uri("/Images/lute.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Mandolin",CountryOfOrigin = "Italy",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A plucked string instrument that came into use during the Renaissance resembling the lute. The mandolin has four courses of strings tuned as "+
                "those of a violin. The fingerboard is fretted and played with a pick or plectrum. Usually the mandolin has a rounded back like that of a lute.",
                InstImage = new BitmapImage(new Uri("/Images/mandolin.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Orpharion",CountryOfOrigin = "England",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A plucked stringed instrument with strings made of wire related to the bandora but of a smaller size and "+
                "tuned like a lute. It enjoyed popularity in the 16th and 17th centuries.",
                InstImage = new BitmapImage(new Uri("/Images/orpharion.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Lyre",CountryOfOrigin = "Ancient Greece",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "An ancient instrument related to the harp. The lyre does not have the triangular shape of the modern harp, but instead the strings are strung "+
                "perpendicularly to the soundbox, with two arms connecting the soundbox to the yoke. The yoke supports the strings opposite the soundbox. This instrument "+
                "was used in ancient Greece and Rome.",
                InstImage = new BitmapImage(new Uri("/Images/lyre.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Violin",CountryOfOrigin = "Italy",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A bowed stringed instrument of soprano range. The modern violin has four strings tuned to g, d', a', and e'' and a range of G below middle "+
                "C to E two octaves above the treble clef. The violin is one of the most popular orchestral instruments, and has been since the Classical era. It is an "+
                "extremely versatile instrument and is capable of a wide range of expression and intensity. All the descendants of the viola da braccio family ( i.e., "+
                "the violin, viola, and violoncello) have four strings, and are played with a bow. The back and belly of the instruments are slightly bulged, the soundholes "+
                "are 'f' shaped, they are fretless, the bodies are longer than the necks, and the fingerboards extend down far over the bodies.",
                InstImage = new BitmapImage(new Uri("/Images/violin.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Kantele",CountryOfOrigin = "Finland",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A Kantele is a traditional plucked string instrument of the dulcimer and zither family native to Finland and Karelia. The kantele has a distinctive "+
                "bell-like sound. The Finnish kantele generally has a diatonic tuning though small kantele with between 5 and 15 strings are often tuned to a gapped mode missing a "+
                "seventh and with the lowest pitched strings tuned to a fourth below the tonic as a drone. Players hold the kantele in their laps or on a small table. There are "+
                "two main techniques to play, either plucking the strings with their fingers or strumming unstopped strings (sometimes with a matchstick).",
                InstImage = new BitmapImage(new Uri("/Images/kantele.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Viola",CountryOfOrigin = "Italy",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The second highest pitched member of the violin family. The viola is similar to the violin in most respects, however, it is larger and is a fifth "+
                "lower in range (whereas the violin has strings tuned to g, d', a', and e'', the viola has strings tuned to c, g, d', and a'). Thus, the "+
                "range of the viola is from C below middle C to A an octave above the treble clef.",
                InstImage = new BitmapImage(new Uri("/Images/viola.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Violoncello",CountryOfOrigin = "Italy",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The third lowest member of the violin family, after the violin and the viola. The violoncello (often shortened to just cello) is actually the lowest "+
                "member of those descended from the viola da braccio with a range of C below the bass clef to G at the top of the treble clef. It is as expressive and versatile as "+
                "the violin, but with a richer, deeper, darker tone.",
                InstImage = new BitmapImage(new Uri("/Images/violoncello.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Double Bass",CountryOfOrigin = "Italy",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The bass member of the violin family. The double bass differs from the rest of the instruments in its family in that it is a descendant of the viola da "+
                "gamba family rather than of the viola da braccio. It has sloping shoulders and four strings, and has a range from C below the bass clef to B-flat in the treble clef, "+
                "and, through the use of harmonics, is even able to reach the G above that. The bow of this instrument is comparatively short, and the strings are rather thick, "+
                "producing a rich, deep sound. This instrument is also called contrabass and bass viol.",
                InstImage = new BitmapImage(new Uri("/Images/doublebass.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Zither",CountryOfOrigin = "Italy",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A stringed instrument consisting of a wooden frame across which are stretched several (about thirty) strings. Five of these strings are used "+
                "for the melody, they are above a fretted fingerboard. The rest of the strings are used for harmony and are not fretted.",
                InstImage = new BitmapImage(new Uri("/Images/zither.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Autoharp",CountryOfOrigin = "Germany",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A zither-type folk instrument of German origin, popular in the USA since the late 19th century. The player strums the strings with fingers or "+
                "plectrum with one hand, while the other hand controls a system of dampers. Each damper dampens all the strings except those of the chord "+
                "required. It is usually rectangular having 15 to 20 strings and a range of two to four octaves.",
                InstImage = new BitmapImage(new Uri("/Images/autoharp.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Dulcimer",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A stringed instrument consisting of a wooden frame over which several strings are stretched. The strings are then "+
                "struck with hammers. This instrument has an ancient history, and is still used as a popular folk instrument.",
                InstImage = new BitmapImage(new Uri("/Images/dulcimer.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Conga",CountryOfOrigin = "Cuba",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The conga, or tumbadora, is a tall, narrow, single-headed Cuban drum. The Cuban conga is staved, like a barrel. These drums were probably made "+
                "from salvaged barrels originally. They are used both in Afro-Caribbean religious music and as the principal instrument in rumba. Congas are now very common "+
                "in Latin music, including salsa music, merengue music and reggae, as well as many other forms of popular music.",
                InstImage = new BitmapImage(new Uri("/Images/conga.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Gong",CountryOfOrigin = "China",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A percussion instrument of Chinese origin, consisting of a great, round, thick disk of metal suspended in a frame and struck with a padded stick. "+
                "When it is struck it produces a very loud sound with a fundamental note and rich overtones. Even though the gong produces a fundamental pitch, "+
                "it is typically considered a non-pitched instrument.",
                InstImage = new BitmapImage(new Uri("/Images/gong.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Tuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Temple Blocks",CountryOfOrigin = "China",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A percussion idiophone similar to the wood block. The temple blocks are typically a set of five hollow wooden (or hard plastic) blocks of different "+
                "sizes with a slit through the middle. When struck with a stick or mallet, the temple blocks sound pitches higher or lower, depeding on their size. The smaller the "+
                "temble block the higher the pitch. Although temple blocks are not considered pitched nstruments, they can produce discernable pitches, and some temple blocks are "+
                "actually tuned to the pentatonic scale. Most often, however, a composer will not indicate which temple block to strike, only which note should be higher in pitch. "+
                "The temple blocks are larger and have a more resonant sound than the wood block.",
                InstImage = new BitmapImage(new Uri("/Images/templeBlocks.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Tuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Timbales",CountryOfOrigin = "Cuba",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A Cuban percussion instrument consisting of a pair of single head, shallow drums tuned to different pitches, and "+
                "performed with two sticks. These drums are essential to Latin American popular music.",
                InstImage = new BitmapImage(new Uri("/Images/timbales.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Tom-tom Drum",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A Drum without snares having wooden shells and two heads. Pairs or several Tom-toms are commnly used in popular music such as jazz music and rock music.",
                InstImage = new BitmapImage(new Uri("/Images/tomtom.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
             instruments.Add(new InstrumentViewModel()
            {
                Name = "Wood Block",CountryOfOrigin = "China",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A percussion instrument that is block of wood that is hollowed out and struck with a stick or mallet.",
                InstImage = new BitmapImage(new Uri("/Images/woodBlock.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Castanets",CountryOfOrigin = "Spain",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "Small, hand-held instrument made of concave shells of ivory or hard wood used by Spanish dancers to accompany dances such as the bolero, cachucha, etc. with a sharp clapping sound.",
                InstImage = new BitmapImage(new Uri("/Images/castanets.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Güiro",CountryOfOrigin = "Puerto Rico",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "Small, hand-held instrument made of concave shells of ivory or hard wood used by Spanish dancers to accompany dances such as the "+
                "bolero, cachucha, etc. with a sharp clapping sound.",
                InstImage = new BitmapImage(new Uri("/Images/guiro.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
             instruments.Add(new InstrumentViewModel()
            {
                Name = "Maracas",CountryOfOrigin = "Puerto Rico",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "Latin American percussion instruments that consist of a gourd with dried seeds inside it and a handle with which to shake it. Maracas "+
                "are played in pairs and their use is not limited to that of Latin American music.",
                InstImage = new BitmapImage(new Uri("/Images/maracas.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Triangle Chime",CountryOfOrigin = "Puerto Rico",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A three-sided (triangular shaped) percussion instrument made of a bent metal bar which is "+
                "sounded by being struck with a steel tangent and produced a high sound of indeterminable pitch.",
                InstImage = new BitmapImage(new Uri("/Images/triangle.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Percussion"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Trautonium",CountryOfOrigin = "Germany",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "Invented by Friedrich Trautwein in 1930, this instrument generates electronic pitches by pressing a wire on a metal bar. The position along "+
                "the bar determined the pitch generated. The instrument had a wide range of timbres available. Richard Strauss and Paul Hindemith both wrote compositions for the trautonium.",
                InstImage = new BitmapImage(new Uri("/Images/trautonium.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Electrophones",HbsSubcategory = "Synthesizer"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Ondes Martenot",CountryOfOrigin = "France",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "Electronic instrument introduced in the 1920's by Maurice Martenot. It produces a single tone with a variable pitch. It is classified as an electrophone.",
                InstImage = new BitmapImage(new Uri("/Images/ondes.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Electrophones",HbsSubcategory = "Synthesizer"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Moog Synthesizer",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "Moog synthesizer may refer to any number of analog synthesizers designed by Dr. Robert Moog or manufactured by Moog Music, and is commonly used as a generic "+
                "term for older-generation analog music synthesizers. The Moog company pioneered the commercial manufacture of modular voltage-controlled analog synthesizer systems in the mid "+
                "1960s. The technological development that led to the creation of the Moog synthesizer was the invention of the transistor, which enabled researchers like Moog to build "+
                "electronic music systems that were considerably smaller, cheaper and far more reliable than earlier vacuum tube-based systems.",
                InstImage = new BitmapImage(new Uri("/Images/synthesizer.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Electrophones",HbsSubcategory = "Synthesizer"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Keyboard",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "An electronic keyboard (also called digital keyboard, portable keyboard, or home keyboard) is an electronic or digital keyboard instrument. The major components "+
                "of a typical modern electronic keyboard are: Musical keyboard, User interface software, rhythm & chord generator, and an amplifier and speaker.",
                InstImage = new BitmapImage(new Uri("/Images/keyboard.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Electrophones",HbsSubcategory = "Keyboards"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Banjo",CountryOfOrigin = "West Africa",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The banjo is a four-, five- or (occasionally) six-stringed instrument with a thin membrane stretched over a frame or cavity as a resonator. The membrane is "+
                "typically a piece of animal skin or plastic, and the frame is typically circular. Simpler forms of the instrument were fashioned by Africans in Colonial America, adapted "+
                "from several African instruments of similar design.",
                InstImage = new BitmapImage(new Uri("/Images/banjo.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Bassjo",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "There are multiple instruments referred to as a bassjo, or bass banjo. The first to enter real production was the five-string cello banjo, tuned one octave below a "+
                "five-string banjo. This was followed by a four-string cello banjo, tuned CGDA in the same range as a cello or mandocello, and modified upright bass versions tuned EADG. "+
                "More recently, true bassjos, tuned EADG and played in conventional horizontal fashion have been introduced.",
                InstImage = new BitmapImage(new Uri("/Images/bassjo.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Acoustic Guitar",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "An acoustic guitar is a guitar that uses only acoustic (as opposed to electronic) means to transmit the strings' vibrational energy to the air in order to "+
                "produce a sound. This typically involves the use of a sound board and a sound box to amplify the vibrations of the string.",
                InstImage = new BitmapImage(new Uri("/Images/12-string-guitar.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Flute",CountryOfOrigin = "Germany",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The flute is a musical instrument of the woodwind family. Unlike woodwind instruments with reeds, a flute is an aerophone or "+
                "reedless wind instrument that produces its sound from the flow of air across an opening",
                InstImage = new BitmapImage(new Uri("/Images/flute.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Harmonica",CountryOfOrigin = "Austria",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The harmonica, also French harp, blues harp, and mouth organ, is a free reed wind instrument used worldwide in nearly every musical genre, "+
                "notably in blues, American folk music, jazz, country, and rock and roll. There are many types of harmonica, including diatonic, chromatic, tremolo, octave, "+
                "orchestral, and bass versions. A harmonica is played by using the mouth (lips and/or tongue) to direct air into and out of one or more holes along a mouthpiece. ",
                InstImage = new BitmapImage(new Uri("/Images/harmonica.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Bagpipes",CountryOfOrigin = "Scotland",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "Bagpipes are a class of musical instrument, aerophones, using enclosed reeds fed from a constant reservoir of air in the form of a bag. "+
                "Though the Scottish Great Highland Bagpipe and Irish uilleann pipes have the greatest international visibility, bagpipes have been played for centuries "+
                "throughout large parts of Europe, the Caucasus, around the Persian Gulf and in Northern Africa. The term 'bagpipe' is equally correct in the singular "+
                "or plural, although in the English language, pipers most commonly talk of 'the pipes', 'a set of pipes' or 'a stand of pipes'.",
                InstImage = new BitmapImage(new Uri("/Images/bagpipes.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Piccolo",CountryOfOrigin = "Italy",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The piccolo is a half-size flute, and a member of the woodwind family of musical "+
                "instruments. The piccolo has most of the same fingerings as its larger sibling, the standard transverse flute, but the sound it produces is an octave "+
                "higher than written. This gave rise to the name 'ottavino,' the name by which the instrument is referred to in the scores of Italian composers.",
                InstImage = new BitmapImage(new Uri("/Images/piccolo.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Ocarina",CountryOfOrigin = "Italy",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The ocarina is a wind instrument in the category of vessel flutes. Variations do exist, but a typical ocarina is an enclosed space with "+
                "four to twelve finger holes and a mouthpiece that projects from the body. It is traditionally made from clay or ceramic, but other materials may also "+
                "be used, such as plastic, wood, glass, metal, or bone. An example of an ocarina made of an animal horn is the medieval German gemshorn.",
                InstImage = new BitmapImage(new Uri("/Images/ocarina.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Recorder",CountryOfOrigin = "Middle Ages",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The recorder is a woodwind musical instrument of the family known as fipple flutes or internal duct flutes—whistle-like instruments which "+
                "include the tin whistle. The recorder is end-blown and the mouth of the instrument is constricted by a wooden plug, known as a block or fipple. It is "+
                "distinguished from other members of the family by having holes for seven fingers (the lower one or two often doubled to facilitate the production of "+
                "semitones) and one for the thumb of the uppermost hand.",
                InstImage = new BitmapImage(new Uri("/Images/recorder.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Tabla",CountryOfOrigin = "India",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The Tabla is a membranophone percussion instrument which are often used in Hindustani classical music and in popular and devotional music of the Indian "+
                "subcontinent. The instrument consists of a pair of hand drums of contrasting sizes and timbres. The tabla is used in some other Asian musical traditions outside of "+
                "India, such as in the Indonesian dangdut genre. Playing technique involves extensive use of the fingers and palms in various configurations to create a wide "+
                "variety of different sounds",
                InstImage = new BitmapImage(new Uri("/Images/tabla.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Tambourine",CountryOfOrigin = "Mesopotamia",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The tambourine is a musical instrument in the percussion family consisting of a frame, often of wood or plastic, with pairs of small metal jingles, "+
                "called 'zils'. Classically the term tambourine denotes an instrument with a drumhead, though some variants may not have a head at all. Tambourines are often used with "+
                "regular percussion sets. They can be mounted, but position is largely down to preference.",
                InstImage = new BitmapImage(new Uri("/Images/tambourine.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Esraj",CountryOfOrigin = "India",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The Esraj is a string instrument found in two forms throughout the north, central, and east regions of India. It is a young instrument by Indian terms, "+
                "being only about 200 years old. The dilruba is found in the north, where it is used in religious music and light classical songs in the urban areas. Its name is "+
                "translated as 'robber of the heart.' The esraj is found in the east and central areas, particularly Bengal (Bangladesh and Indian states of West Bengal and Tripura) "+
                "and it is used in a somewhat wider variety of musical styles than is the dilruba.",
                InstImage = new BitmapImage(new Uri("/Images/esraj.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Marxophone",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The Marxophone is a fretless zither with two octaves of double melody strings in the key of C major (middle C to C''), and four sets of chord "+
                "strings (C major, G major, F major, and D7). The player typically strums the chords with the left hand. The right hand plays the melody strings by depressing "+
                "spring steel strips that hold small lead hammers over the strings. A brief stab on a metal strip bounces the hammer off a string pair to produce a single note. "+
                "Holding the strip down makes the hammer bounce on the double strings, which produces a mandolin-like tremolo.",
                InstImage = new BitmapImage(new Uri("/Images/marxophone.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Keyboards"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Shamisen",CountryOfOrigin = "Japan",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The Shamisen is a three-stringed, Japanese musical instrument played with a plectrum called a bachi. The Japanese pronunciation is usually 'shamisen' "+
                "but sometimes 'jamisen' when used as a suffix (e.g., Tsugaru-jamisen). (In western Japan, and often in Edo-period sources, it is sometimes 'samisen.') The shamisen is "+
                "a plucked stringed instrument. Its construction follows a model similar to that of a guitar or a banjo, with a neck and strings stretched across a resonating body.",
                InstImage = new BitmapImage(new Uri("/Images/shamisen.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Cornet",CountryOfOrigin = "France",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "Like the trumpet, the cornet has valves and is usually pitched in B flat. In order to play it the musician blows into the mouthpiece, "+
                "presses the finger buttons, also known as valves, and moves the tuning slide.",
                InstImage = new BitmapImage(new Uri("/Images/cornet.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Brass"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Cymbal",CountryOfOrigin = "China",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The player holds the strap attached to each cymbal and brushes it against each other or clash it together. It can either be held horizontally or vertically "+
                "and played either loudly or softly depending on the music. As part of a drum set, the cymbal may be controlled by a foot pedal or struck using a drumstick.",
                InstImage = new BitmapImage(new Uri("/Images/cymbal.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Dulcian",CountryOfOrigin = "Middle Ages",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The player places his/her lips on the reed and blows; the fingerholes are opened and closed to produce different notes. The dulcian was "+
                "not only an outdoor instrument, it was also used in enclosed locations such as churches and as instruments in chamber music.",
                InstImage = new BitmapImage(new Uri("/Images/dulcian.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Dynamophone",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The dynamophone is huge and quite heavy, it called for two musicians to play it. Telephone receivers are used to convert impulses produced by this instruments "+
                "electromagnetic generators. The dynamophone is the ancestor of today's electronic synthesizers. It disappeared during World War 1. Three versions of this instrument were "+
                "created - Mark I, Mark II and the final version was completed in 1911.",
                InstImage = new BitmapImage(new Uri("/Images/dynamophone.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Electrophones",HbsSubcategory = "Synthetic"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Glockenspiel",CountryOfOrigin = "Germany",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "Glockenspiels have tuned steel bars or tubes which are struck by the musician using two beaters. The beaters may be made from metal, wood or rubber. The sound "+
                "of glockenspiels are bright, much like the sound of bells. Orchestral glockenspiels have two rows of steel bars, the first row functions much like the white keys on a piano. "+
                "The second row represents the black keys.",
                InstImage = new BitmapImage(new Uri("/Images/glockenspiel.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Tuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Metallophone",CountryOfOrigin = "China",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "Metallophone, generally, the difference between metallophones and xylophones is that metallophones are amde of metal bars which are struck, while xylophones are "+
                "made of wooden bars. Basically, metallophiones are played the same way as xylophones, by striking the metal bars with a beater or mallet. There are two main types of "+
                "metallophones used in Indonesian gamelan orchestra - the Saron and Gender Family. These two types of metallophones differ in the size of its metal bars. Sarons have thick "+
                "bars while Genders have thinner bars. They also vary in construction as well as the force needed to play it. Sarons may be played either soft or loud while Genders are usually played softly.",
                InstImage = new BitmapImage(new Uri("/Images/metallophone.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Tuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Serpent",CountryOfOrigin = "France",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The serpent is the bass wind instrument, descended from the cornett, and a distant ancestor of the tuba, with a mouthpiece like a brass instrument but side holes "+
                "like a woodwind. It is usually a long cone bent into a snakelike shape, hence the name. The serpent is closely related to the cornett, although it is not part of the cornett "+
                "family, due to the absence of a thumb hole. It is generally made out of wood, with walnut being a particularly popular choice. The outside is covered with dark brown or "+
                "black leather. Despite wooden construction and the fact that it has fingerholes rather than valves, it is usually classed as a brass, with the Hornbostel-Sachs scheme of "+
                "musical instrument classification placing it alongside trumpets.",
                InstImage = new BitmapImage(new Uri("/Images/serpent.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Shawm",CountryOfOrigin = "China",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The shawm was a medieval and Renaissance musical instrument of the woodwind family made in Europe from the 12th century (at the latest) until the 17th century. "+
                "It was likely of ancient origin and was imported to Europe from the Islamic East at some point between the 9th and 12th centuries. All shawms (excepting the smallest) had at "+
                "least one key allowing a downward extension of the compass; the keywork was typically covered by a perforated wooden cover called the fontanelle. ",
                InstImage = new BitmapImage(new Uri("/Images/shawm.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Cowbell",CountryOfOrigin = "Middle Ages",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The cowbell is an idiophone hand percussion instrument used in various styles of music including salsa and infrequently in popular music. It "+
                "is named after the similar bell historically used by herdsmen to keep track of the whereabouts of cows.",
                InstImage = new BitmapImage(new Uri("/Images/cowbell.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Steel Drum",CountryOfOrigin = "Trinidad & Tobago",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The modern pan is a chromatically pitched percussion instrument (although some toy or novelty steelpans are tuned diatonically, and some older style round the "+
                "neck instruments have even fewer notes), made from 55 gallon drums that formerly contained oil and like substances. Drum refers to the steel drum containers from which the "+
                "pans are made; the steeldrum is more correctly called a steel pan or pan as it falls into the idiophone family of instruments, and so is not a drum which is a membranophone.",
                InstImage = new BitmapImage(new Uri("/Images/steeldrum.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Idiophones",HbsSubcategory = "Tuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Kazoo",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The kazoo is a musical instrument that adds a 'buzzing' timbral quality to a player's voice when the player vocalizes into it. The kazoo is a type of mirliton, "+
                "which is a membranophone, one of a class of instruments which modifies its player's voice by way of a vibrating membrane.",
                InstImage = new BitmapImage(new Uri("/Images/kazoo.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Wheelharp",CountryOfOrigin = "United States",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The wheelharp is a musical instrument with bowed strings controlled by a keyboard and foot-controlled motor. Co-invented by Jon Jones and Mitchell Manger, it "+
                "debuted at the 2013 NAMM Show in Anaheim, California. According to the Wall Street Journal, it 'looks and works like a cross between a harpsichord and a hurdy-gurdy: a motor "+
                "driven wheel spins, rubbing against strings when the player depresses a key.'",
                InstImage = new BitmapImage(new Uri("/Images/wheelharp.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Hardingfele",CountryOfOrigin = "Norway",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The hardingfele is a traditional stringed instrument used originally to play the music of Norway. In modern designs, this type of fiddle is very similar to the "+
                "violin, though with eight or nine strings (rather than four as on a standard violin) and thinner wood. Four of the strings are strung and played like a violin, while the rest, "+
                "aptly named understrings or sympathetic strings, resonate under the influence of the other four, providing a pleasant haunting, echo-like sound.",
                InstImage = new BitmapImage(new Uri("/Images/hardingfele.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Contrabass Flute",CountryOfOrigin = "Germany",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The contrabass flute is one of the rarer members of the flute family. It is used mostly in flute ensembles. Its range is similar to that of the regular concert flute, "+
                "except that it is pitched two octaves lower; the lowest performable note is two octaves below middle C (the lowest C on the cello). Many contrabass flutes in C are also equipped "+
                "with a low B, (in the same manner as many modern standard sized flutes are.) Contrabass flutes are only available from select flute makers.",
                InstImage = new BitmapImage(new Uri("/Images/contrabassflute.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Igil",CountryOfOrigin = "Siberia",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The igil is a two-stringed traditional instrument from the Tuva region of Siberia, just north of Mongolia. A very few old igils are made from a horse's skull, "+
                "which reflects the legend that the igil was first created on instructions from a horse that appeared in a dream. The igil is sometimes referred to as a horse head fiddle.",
                InstImage = new BitmapImage(new Uri("/Images/igil.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Stylophone",CountryOfOrigin = "Siberia",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The igil is a two-stringed traditional instrument from the Tuva region of Siberia, just north of Mongolia. A very few old igils are made from a horse's skull, "+
                "which reflects the legend that the igil was first created on instructions from a horse that appeared in a dream. The igil is sometimes referred to as a horse head fiddle.",
                InstImage = new BitmapImage(new Uri("/Images/stylophone.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Electrophones",HbsSubcategory = "Synthesizer"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Omnichord",CountryOfOrigin = "Japan",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The Omnichord is an electronic musical instrument, introduced in 1981 and manufactured by the Suzuki Musical Instrument Corporation. It typically features a "+
                "touch plate, and buttons for major, minor, and diminished chords. The most basic method of playing the instrument is to press the chord buttons and swipe the touch plate with "+
                "a finger or guitar pick in imitation of strumming a stringed instrument. Originally designed as an electronic substitute for an autoharp, the Omnichord has become popular as "+
                "an individual instrument in its own right, due to its unique, chiming timbre and its value as a kitsch object.",
                InstImage = new BitmapImage(new Uri("/Images/omnichord.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Electrophones",HbsSubcategory = "Synthesizer"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Otomatone",CountryOfOrigin = "Japan",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The Otamatone is a musical instrument developed in Japan by the Cube Works Company along with Maywa Denki and Novmichi Tosa. It is a musical-note shaped singing toy "+
                "which requires two hands to be played: while one hand holds and/or squeezes the 'head', the other hand controls the pitch of the tune by sliding the finger up and down the stem. "+
                "The sound made by this instrument is often compared to the sound of a theremin and a synthesizer",
                InstImage = new BitmapImage(new Uri("/Images/otomatone.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Electrophones",HbsSubcategory = "Synthesizer"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "TB-303",CountryOfOrigin = "Japan",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "This early 1980s synthesiser was originally designed to replace the bass guitar. Unfortunately the instrument sounded nothing like a bass guitar and failed to catch "+
                "on. Several years after the synth was dropped by the manufacturer a new group of musicians found the machine in second hand shops and discovered it can create totally weird "+
                "trancey sounds – these sounds shaped house music.",
                InstImage = new BitmapImage(new Uri("/Images/tb303.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Electrophones",HbsSubcategory = "Synthesizer"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Fiddle",CountryOfOrigin = "Middle Ages",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "A fiddle is any bowed string musical instrument, most often the violin. It is also a colloquial term for the instrument used by players in all genres, including "+
                "classical music. Fiddle playing, or fiddling, refers to various styles of music. Common distinctions between violins and fiddles reflect the differences in the instruments used "+
                "to play folk and classical music. However, it is not uncommon for classically trained violinists to play folk music, and today many fiddle players have classical training. "+
                "Many traditional (folk) styles are aural traditions, so are taught 'by ear' rather than with written music.",
                InstImage = new BitmapImage(new Uri("/Images/fiddle.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Bodhrán",CountryOfOrigin = "Ireland",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The bodhrán is an Irish frame drum ranging from 25 to 65 cm in diameter, with most drums measuring 35 to 45 cm. The sides of the drum are 9 to 20 cm deep. A goatskin "+
                "head is tacked to one side (synthetic heads or other animal skins are sometimes used). The other side is open-ended for one hand to be placed against the inside of the drum head "+
                "to control the pitch and timbre.",
                InstImage = new BitmapImage(new Uri("/Images/bodhran.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Membranophones",HbsSubcategory = "Untuned"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Tin Whistle",CountryOfOrigin = "Ireland",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The tin whistle, also called the penny whistle, English flageolet, Scottish penny whistle, tin flageolet, Irish whistle, feadóg stáin (or simply feadóg) and Clarke "+
                "London Flageolet is a simple, six-holed woodwind instrument. It is a fipple flute, putting it in the same category as the recorder, Native American flute, and other woodwind "+
                "instruments that meet such criteria. A tin whistle player is called a tin whistler or simply a whistler. The tin whistle is closely associated with Celtic music.",
                InstImage = new BitmapImage(new Uri("/Images/tinwhistle.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Aerophones",HbsSubcategory = "Woodwinds"
            });
            instruments.Add(new InstrumentViewModel()
            {
                Name = "Bouzouki",CountryOfOrigin = "Greece",
                Artists = new ObservableCollection<ArtistViewModel>(new List<ArtistViewModel>()
                {
                    new ArtistViewModel(){Name="Iz Kamakawiwoʻole"}
                }),
                Description = "The bouzouki is a Greek musical instrument that was brought to Greece in the 1900s by immigrants "+
                "from Asia Minor, and quickly became the central instrument to the rebetika genre and its music branches. A mainstay of modern Greek music, the front of the body is flat "+
                "and is usually heavily inlaid with mother-of-pearl. The instrument is played with a plectrum and has a sharp metallic sound, reminiscent of a mandolin but pitched lower.",
                InstImage = new BitmapImage(new Uri("/Images/bouzouki.png", UriKind.RelativeOrAbsolute)),
                HbsCategory = "Chordophones",HbsSubcategory = "Strings"
            });
            
            
            this.IsDataLoaded = true;
        }



        //INOTIFYPROPERTYCHANGED MANDITORY METHOD OVERRIDE
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
